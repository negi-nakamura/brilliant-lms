using brilliant_lms.Data;
using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Models.Responses;
using Dapper;
using MySql.Data.MySqlClient;

namespace brilliant_lms.Repositories
{
    public class InvitationRepository
    {
        private SqlConnectionFactory factory = SqlConnectionFactory.Instance;

        public async Task SendAsync(int userId, int classroomId, AddMemberRequest request)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                await connection.OpenAsync();
                using MySqlTransaction transaction = await connection.BeginTransactionAsync();
                string sql = """
                    SELECT c.owner_id FROM classrooms c
                    WHERE c.classroom_id = @ClassroomId AND c.is_archived = FALSE
                      AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members teacher
                        WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @UserId AND teacher.role = 'Teacher'))
                    FOR UPDATE;
                    """;
                int? ownerId = await connection.QuerySingleOrDefaultAsync<int?>(sql, new { UserId = userId, ClassroomId = classroomId }, transaction);
                if (ownerId == null)
                    throw new InvalidOperationException("This classroom is archived, unavailable, or you do not have teacher access.");
                int? inviteeId = await connection.QuerySingleOrDefaultAsync<int?>("SELECT user_id FROM users WHERE email = @Email;", new { request.Email }, transaction);
                if (inviteeId == null)
                    throw new InvalidOperationException("No account was found with this email address.");
                if (inviteeId == userId || inviteeId == ownerId)
                    throw new InvalidOperationException("This account is already a member of the class.");
                sql = "SELECT COUNT(*) FROM members WHERE classroom_id = @ClassroomId AND user_id = @InviteeId;";
                int members = await connection.ExecuteScalarAsync<int>(sql, new { ClassroomId = classroomId, InviteeId = inviteeId }, transaction);
                if (members > 0) throw new InvalidOperationException("This account is already a member of the class.");
                sql = """
                    SELECT COUNT(*) FROM classroom_invitations i
                    WHERE i.classroom_id = @ClassroomId AND i.invitee_id = @InviteeId AND i.status = 'Pending'
                      AND (i.inviter_id = @OwnerId OR EXISTS (SELECT 1 FROM members teacher
                        WHERE teacher.classroom_id = i.classroom_id AND teacher.user_id = i.inviter_id AND teacher.role = 'Teacher'));
                    """;
                int pending = await connection.ExecuteScalarAsync<int>(sql, new { ClassroomId = classroomId, InviteeId = inviteeId, OwnerId = ownerId }, transaction);
                if (pending > 0) throw new InvalidOperationException("This account already has a pending invitation to this class.");
                sql = """
                    INSERT INTO classroom_invitations (classroom_id, inviter_id, invitee_id, role)
                    VALUES (@ClassroomId, @InviterId, @InviteeId, @Role);
                    """;
                await connection.ExecuteAsync(sql, new { ClassroomId = classroomId, InviterId = userId, InviteeId = inviteeId, request.Role }, transaction);
                await transaction.CommitAsync();
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to send the invitation. Please check your database connection and try again.", exception);
            }
        }

        public async Task<List<InvitationDirectoryItem>> GetPendingInvitationsAsync(int userId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    SELECT i.invitation_id AS Id, i.classroom_id AS ClassroomId, i.inviter_id AS InviterId,
                           i.invitee_id AS InviteeId, i.role AS Role, i.status AS Status,
                           i.created_at AS CreatedAt, i.responded_at AS RespondedAt, c.name AS ClassroomName,
                           inviter.first_name AS InviterFirstName, inviter.middle_name AS InviterMiddleName,
                           inviter.last_name AS InviterLastName
                    FROM classroom_invitations i INNER JOIN classrooms c ON c.classroom_id = i.classroom_id
                    INNER JOIN users inviter ON inviter.user_id = i.inviter_id
                    WHERE i.invitee_id = @UserId AND i.status = 'Pending' AND c.is_archived = FALSE
                      AND (c.owner_id = i.inviter_id OR EXISTS (SELECT 1 FROM members teacher
                        WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = i.inviter_id AND teacher.role = 'Teacher'))
                    ORDER BY i.created_at DESC, i.invitation_id DESC;
                    """;
                var invitations = await connection.QueryAsync<InvitationDirectoryItem>(sql, new { UserId = userId });
                return invitations.ToList();
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to load your invitations. Please check your database connection and try again.", exception);
            }
        }

        public async Task<List<InvitationDirectoryItem>> GetDeclinedInvitationsAsync(int userId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    SELECT i.invitation_id AS Id, i.classroom_id AS ClassroomId, i.inviter_id AS InviterId,
                           i.invitee_id AS InviteeId, i.role AS Role, i.status AS Status,
                           i.created_at AS CreatedAt, i.responded_at AS RespondedAt, c.name AS ClassroomName,
                           inviter.first_name AS InviterFirstName, inviter.middle_name AS InviterMiddleName,
                           inviter.last_name AS InviterLastName
                    FROM classroom_invitations i INNER JOIN classrooms c ON c.classroom_id = i.classroom_id
                    INNER JOIN users inviter ON inviter.user_id = i.inviter_id
                    WHERE i.invitee_id = @UserId AND i.status = 'Declined'
                    ORDER BY i.responded_at DESC, i.invitation_id DESC;
                    """;
                var invitations = await connection.QueryAsync<InvitationDirectoryItem>(sql, new { UserId = userId });
                return invitations.ToList();
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to load declined invitations. Please check your database connection and try again.", exception);
            }
        }

        public async Task AcceptAsync(int userId, int invitationId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                await connection.OpenAsync();
                using MySqlTransaction transaction = await connection.BeginTransactionAsync();
                string sql = """
                    SELECT classroom_id FROM classroom_invitations
                    WHERE invitation_id = @InvitationId AND invitee_id = @UserId AND status = 'Pending';
                    """;
                int? classroomId = await connection.QuerySingleOrDefaultAsync<int?>(sql, new { InvitationId = invitationId, UserId = userId }, transaction);
                if (classroomId == null) throw new InvalidOperationException("This invitation is no longer pending or does not belong to you.");
                sql = "SELECT classroom_id FROM classrooms WHERE classroom_id = @ClassroomId AND is_archived = FALSE FOR UPDATE;";
                int? active = await connection.QuerySingleOrDefaultAsync<int?>(sql, new { ClassroomId = classroomId }, transaction);
                if (active == null) throw new InvalidOperationException("This classroom is archived or no longer available.");
                sql = """
                    SELECT i.invitation_id AS Id, i.classroom_id AS ClassroomId, i.invitee_id AS InviteeId, i.role AS Role
                    FROM classroom_invitations i INNER JOIN classrooms c ON c.classroom_id = i.classroom_id
                    WHERE i.invitation_id = @InvitationId AND i.invitee_id = @UserId AND i.status = 'Pending' AND c.is_archived = FALSE
                      AND (c.owner_id = i.inviter_id OR EXISTS (SELECT 1 FROM members teacher
                        WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = i.inviter_id AND teacher.role = 'Teacher'))
                    FOR UPDATE;
                    """;
                ClassroomInvitation invitation = await connection.QuerySingleOrDefaultAsync<ClassroomInvitation>(sql,
                    new { InvitationId = invitationId, UserId = userId }, transaction)
                    ?? throw new InvalidOperationException("This invitation is no longer available or the sender no longer has teacher access.");
                sql = "SELECT COUNT(*) FROM members WHERE classroom_id = @ClassroomId AND user_id = @UserId;";
                int existing = await connection.ExecuteScalarAsync<int>(sql, new { invitation.ClassroomId, UserId = userId }, transaction);
                if (existing == 0)
                {
                    sql = "INSERT INTO members (classroom_id, user_id, role) VALUES (@ClassroomId, @UserId, @Role);";
                    await connection.ExecuteAsync(sql, new { invitation.ClassroomId, UserId = userId, invitation.Role }, transaction);
                }
                sql = """
                    UPDATE classroom_invitations SET status = 'Accepted', responded_at = CURRENT_TIMESTAMP
                    WHERE invitation_id = @InvitationId AND invitee_id = @UserId AND status = 'Pending';
                    """;
                await connection.ExecuteAsync(sql, new { InvitationId = invitationId, UserId = userId }, transaction);
                await transaction.CommitAsync();
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to accept the invitation. Please check your database connection and try again.", exception);
            }
        }

        public async Task DeclineAsync(int userId, int invitationId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    UPDATE classroom_invitations SET status = 'Declined', responded_at = CURRENT_TIMESTAMP
                    WHERE invitation_id = @InvitationId AND invitee_id = @UserId AND status = 'Pending';
                    """;
                int affected = await connection.ExecuteAsync(sql, new { InvitationId = invitationId, UserId = userId });
                if (affected != 1) throw new InvalidOperationException("This invitation is no longer pending or does not belong to you.");
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to decline the invitation. Please check your database connection and try again.", exception);
            }
        }

        public async Task<List<InvitationDirectoryItem>> GetSentPendingInvitationsAsync(int userId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    SELECT i.invitation_id AS Id, i.classroom_id AS ClassroomId, i.inviter_id AS InviterId,
                           i.invitee_id AS InviteeId, i.role AS Role, i.status AS Status,
                           i.created_at AS CreatedAt, i.responded_at AS RespondedAt, c.name AS ClassroomName,
                           invitee.first_name AS InviteeFirstName, invitee.middle_name AS InviteeMiddleName,
                           invitee.last_name AS InviteeLastName, invitee.email AS InviteeEmail
                    FROM classroom_invitations i INNER JOIN classrooms c ON c.classroom_id = i.classroom_id
                    INNER JOIN users invitee ON invitee.user_id = i.invitee_id
                    WHERE i.inviter_id = @UserId AND i.status = 'Pending' AND c.is_archived = FALSE
                      AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members teacher
                        WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @UserId AND teacher.role = 'Teacher'))
                    ORDER BY i.created_at DESC, i.invitation_id DESC;
                    """;
                var invitations = await connection.QueryAsync<InvitationDirectoryItem>(sql, new { UserId = userId });
                return invitations.ToList();
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to load sent invitations. Please check your database connection and try again.", exception);
            }
        }

        public async Task<List<InvitationDirectoryItem>> GetSentDeclinedInvitationsAsync(int userId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    SELECT i.invitation_id AS Id, i.classroom_id AS ClassroomId, i.inviter_id AS InviterId,
                           i.invitee_id AS InviteeId, i.role AS Role, i.status AS Status,
                           i.created_at AS CreatedAt, i.responded_at AS RespondedAt, c.name AS ClassroomName,
                           invitee.first_name AS InviteeFirstName, invitee.middle_name AS InviteeMiddleName,
                           invitee.last_name AS InviteeLastName, invitee.email AS InviteeEmail
                    FROM classroom_invitations i INNER JOIN classrooms c ON c.classroom_id = i.classroom_id
                    INNER JOIN users invitee ON invitee.user_id = i.invitee_id
                    WHERE i.inviter_id = @UserId AND i.status = 'Declined' AND c.is_archived = FALSE
                      AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members teacher
                        WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @UserId AND teacher.role = 'Teacher'))
                    ORDER BY i.created_at DESC, i.invitation_id DESC;
                    """;
                var invitations = await connection.QueryAsync<InvitationDirectoryItem>(sql, new { UserId = userId });
                return invitations.ToList();
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to load sent invitations. Please check your database connection and try again.", exception);
            }
        }

        public async Task CancelAsync(int userId, int invitationId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    DELETE i FROM classroom_invitations i INNER JOIN classrooms c ON c.classroom_id = i.classroom_id
                    WHERE i.invitation_id = @InvitationId AND i.inviter_id = @UserId AND i.status = 'Pending'
                      AND c.is_archived = FALSE
                      AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members teacher
                        WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @UserId AND teacher.role = 'Teacher'));
                    """;
                int affected = await connection.ExecuteAsync(sql, new { UserId = userId, InvitationId = invitationId });
                if (affected != 1) throw new InvalidOperationException("This invitation is no longer pending or you no longer have teacher access.");
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to cancel the invitation. Please check your database connection and try again.", exception);
            }
        }

        public async Task ResendAsync(int userId, int invitationId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                await connection.OpenAsync();
                using MySqlTransaction transaction = await connection.BeginTransactionAsync();
                string sql = """
                    SELECT classroom_id FROM classroom_invitations
                    WHERE invitation_id = @InvitationId AND inviter_id = @UserId AND status = 'Declined';
                    """;
                int? classroomId = await connection.QuerySingleOrDefaultAsync<int?>(sql, new { UserId = userId, InvitationId = invitationId }, transaction);
                if (classroomId == null) throw new InvalidOperationException("This invitation is no longer declined or does not belong to you.");
                sql = """
                    SELECT c.owner_id FROM classrooms c WHERE c.classroom_id = @ClassroomId AND c.is_archived = FALSE
                      AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members teacher
                        WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @UserId AND teacher.role = 'Teacher'))
                    FOR UPDATE;
                    """;
                int? ownerId = await connection.QuerySingleOrDefaultAsync<int?>(sql, new { UserId = userId, ClassroomId = classroomId }, transaction);
                if (ownerId == null) throw new InvalidOperationException("This classroom is archived, unavailable, or you do not have teacher access.");
                sql = """
                    SELECT invitation_id AS Id, classroom_id AS ClassroomId, invitee_id AS InviteeId FROM classroom_invitations
                    WHERE invitation_id = @InvitationId AND inviter_id = @UserId AND status = 'Declined' FOR UPDATE;
                    """;
                ClassroomInvitation invitation = await connection.QuerySingleOrDefaultAsync<ClassroomInvitation>(sql, new { UserId = userId, InvitationId = invitationId }, transaction)
                    ?? throw new InvalidOperationException("This invitation is no longer declined.");
                sql = "SELECT COUNT(*) FROM members WHERE classroom_id = @ClassroomId AND user_id = @InviteeId;";
                int members = await connection.ExecuteScalarAsync<int>(sql, new { invitation.ClassroomId, invitation.InviteeId }, transaction);
                if (members > 0 || invitation.InviteeId == ownerId) throw new InvalidOperationException("This account is already a member of the class.");
                sql = """
                    SELECT COUNT(*) FROM classroom_invitations i WHERE i.classroom_id = @ClassroomId
                      AND i.invitee_id = @InviteeId AND i.status = 'Pending'
                      AND (i.inviter_id = @OwnerId OR EXISTS (SELECT 1 FROM members teacher
                        WHERE teacher.classroom_id = i.classroom_id AND teacher.user_id = i.inviter_id AND teacher.role = 'Teacher'));
                    """;
                int pending = await connection.ExecuteScalarAsync<int>(sql, new { invitation.ClassroomId, invitation.InviteeId, OwnerId = ownerId }, transaction);
                if (pending > 0) throw new InvalidOperationException("This account already has a pending invitation to this class.");
                sql = """
                    UPDATE classroom_invitations SET status = 'Pending', created_at = CURRENT_TIMESTAMP, responded_at = NULL
                    WHERE invitation_id = @InvitationId AND inviter_id = @UserId AND status = 'Declined';
                    """;
                await connection.ExecuteAsync(sql, new { UserId = userId, InvitationId = invitationId }, transaction);
                await transaction.CommitAsync();
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to resend the invitation. Please check your database connection and try again.", exception);
            }
        }
    }
}
