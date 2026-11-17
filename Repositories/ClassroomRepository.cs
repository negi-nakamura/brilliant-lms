using brilliant_lms.Data;
using brilliant_lms.Models.Entities;
using Dapper;
using brilliant_lms.Models.Responses;
using MySql.Data.MySqlClient;

namespace brilliant_lms.Repositories
{
    public class ClassroomRepository
    {
        private SqlConnectionFactory factory = SqlConnectionFactory.Instance;

        public async Task<List<ClassroomDirectoryItem>> GetStudentClassroomsAsync(int userId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();

                string sql = """
                    SELECT c.classroom_id AS Id, c.owner_id AS OwnerId, c.name AS Name,
                           c.section AS Section, c.subject AS Subject, c.room AS Room,
                           c.schedule AS Schedule, c.level AS Level, c.join_code AS JoinCode,
                           c.is_archived AS IsArchived, c.created_at AS CreatedAt,
                           m.joined_at AS JoinedAt,
                           teacher.first_name AS TeacherFirstName,
                           teacher.middle_name AS TeacherMiddleName,
                           teacher.last_name AS TeacherLastName
                    FROM classrooms c
                    INNER JOIN members m ON m.classroom_id = c.classroom_id
                    INNER JOIN users teacher ON teacher.user_id = c.owner_id
                    WHERE m.user_id = @UserId AND m.role = 'Student' AND c.is_archived = FALSE
                    ORDER BY c.name, c.classroom_id;
                    """;

                var classrooms = await connection.QueryAsync<ClassroomDirectoryItem>(sql, new { UserId = userId });
                return classrooms.ToList();
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to load your classrooms. Please check your database connection and try again.", exception);
            }
        }

        public async Task<List<ClassroomDirectoryItem>> GetTeacherClassroomsAsync(int userId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();

                string sql = """
                    SELECT c.classroom_id AS Id, c.owner_id AS OwnerId, c.name AS Name,
                           c.section AS Section, c.subject AS Subject, c.room AS Room,
                           c.schedule AS Schedule, c.level AS Level, c.join_code AS JoinCode,
                           c.is_archived AS IsArchived, c.created_at AS CreatedAt,
                           m.joined_at AS JoinedAt,
                           teacher.first_name AS TeacherFirstName,
                           teacher.middle_name AS TeacherMiddleName,
                           teacher.last_name AS TeacherLastName
                    FROM classrooms c
                    INNER JOIN members m ON m.classroom_id = c.classroom_id
                    INNER JOIN users teacher ON teacher.user_id = c.owner_id
                    WHERE m.user_id = @UserId AND m.role = 'Teacher' AND c.is_archived = FALSE
                    ORDER BY c.name, c.classroom_id;
                    """;

                var classrooms = await connection.QueryAsync<ClassroomDirectoryItem>(sql, new { UserId = userId });
                return classrooms.ToList();
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to load your classrooms. Please check your database connection and try again.", exception);
            }
        }

        public async Task<ClassroomDirectoryItem> GetClassroomDetailsAsync(int userId, int classroomId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    SELECT c.classroom_id AS Id, c.owner_id AS OwnerId, c.name AS Name,
                           c.section AS Section, c.subject AS Subject, c.room AS Room,
                           c.schedule AS Schedule, c.level AS Level, c.join_code AS JoinCode,
                           c.is_archived AS IsArchived, c.created_at AS CreatedAt,
                           teacher.first_name AS TeacherFirstName, teacher.middle_name AS TeacherMiddleName,
                           teacher.last_name AS TeacherLastName, m.joined_at AS JoinedAt
                    FROM classrooms c
                    INNER JOIN users teacher ON teacher.user_id = c.owner_id
                    LEFT JOIN members m ON m.classroom_id = c.classroom_id AND m.user_id = @UserId
                    WHERE c.classroom_id = @ClassroomId AND (c.owner_id = @UserId OR m.member_id IS NOT NULL);
                    """;
                return await connection.QuerySingleOrDefaultAsync<ClassroomDirectoryItem>(sql, new { UserId = userId, ClassroomId = classroomId })
                    ?? throw new InvalidOperationException("This classroom is unavailable or you are no longer a member.");
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to load classroom details. Please check your database connection and try again.", exception);
            }
        }

        public async Task<Classroom> UpdateAsync(int userId, Classroom classroom)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    UPDATE classrooms c SET c.name = @Name, c.section = @Section, c.subject = @Subject,
                        c.room = @Room, c.schedule = @Schedule, c.level = @Level
                    WHERE c.classroom_id = @Id AND c.is_archived = FALSE
                      AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members teacher
                          WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @UserId AND teacher.role = 'Teacher'));

                    SELECT c.classroom_id AS Id, c.owner_id AS OwnerId, c.name AS Name,
                           c.section AS Section, c.subject AS Subject, c.room AS Room,
                           c.schedule AS Schedule, c.level AS Level, c.join_code AS JoinCode,
                           c.is_archived AS IsArchived, c.created_at AS CreatedAt
                    FROM classrooms c
                    WHERE c.classroom_id = @Id AND c.is_archived = FALSE
                      AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members teacher
                          WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @UserId AND teacher.role = 'Teacher'));
                    """;
                return await connection.QuerySingleOrDefaultAsync<Classroom>(sql, new
                {
                    UserId = userId,
                    classroom.Id,
                    classroom.Name,
                    classroom.Section,
                    classroom.Subject,
                    classroom.Room,
                    classroom.Schedule,
                    classroom.Level
                }) ?? throw new InvalidOperationException("This classroom is archived, unavailable, or you do not have teacher access.");
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to update classroom details. Please check your database connection and try again.", exception);
            }
        }

        public async Task LeaveAsync(int userId, int classroomId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();

                string sql = """
                    DELETE m FROM members m
                    INNER JOIN classrooms c ON c.classroom_id = m.classroom_id
                    WHERE m.classroom_id = @ClassroomId AND m.user_id = @UserId
                      AND m.role = 'Student' AND c.owner_id <> @UserId AND c.is_archived = FALSE;
                    """;

                int affected = await connection.ExecuteAsync(sql, new { ClassroomId = classroomId, UserId = userId });
                if (affected != 1)
                    throw new InvalidOperationException("This classroom is archived, unavailable, or you are no longer a student in it.");
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to leave the classroom. Please check your database connection and try again.", exception);
            }
        }

        public async Task<List<ClassroomDirectoryItem>> GetArchivedStudentClassroomsAsync(int userId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();

                string sql = """
                    SELECT c.classroom_id AS Id, c.owner_id AS OwnerId, c.name AS Name,
                           c.section AS Section, c.subject AS Subject, c.room AS Room,
                           c.schedule AS Schedule, c.level AS Level, c.join_code AS JoinCode,
                           c.is_archived AS IsArchived, c.created_at AS CreatedAt,
                           m.joined_at AS JoinedAt,
                           teacher.first_name AS TeacherFirstName,
                           teacher.middle_name AS TeacherMiddleName,
                           teacher.last_name AS TeacherLastName
                    FROM classrooms c
                    INNER JOIN members m ON m.classroom_id = c.classroom_id
                    INNER JOIN users teacher ON teacher.user_id = c.owner_id
                    WHERE m.user_id = @UserId AND m.role = 'Student' AND c.is_archived = TRUE
                    ORDER BY c.name, c.classroom_id;
                    """;

                var classrooms = await connection.QueryAsync<ClassroomDirectoryItem>(sql, new { UserId = userId });
                return classrooms.ToList();
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to load your classrooms. Please check your database connection and try again.", exception);
            }
        }

        public async Task<List<ClassroomDirectoryItem>> GetArchivedTeacherClassroomsAsync(int userId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();

                string sql = """
                    SELECT c.classroom_id AS Id, c.owner_id AS OwnerId, c.name AS Name,
                           c.section AS Section, c.subject AS Subject, c.room AS Room,
                           c.schedule AS Schedule, c.level AS Level, c.join_code AS JoinCode,
                           c.is_archived AS IsArchived, c.created_at AS CreatedAt,
                           m.joined_at AS JoinedAt,
                           teacher.first_name AS TeacherFirstName,
                           teacher.middle_name AS TeacherMiddleName,
                           teacher.last_name AS TeacherLastName
                    FROM classrooms c
                    INNER JOIN members m ON m.classroom_id = c.classroom_id
                    INNER JOIN users teacher ON teacher.user_id = c.owner_id
                    WHERE m.user_id = @UserId AND m.role = 'Teacher' AND c.is_archived = TRUE
                    ORDER BY c.name, c.classroom_id;
                    """;

                var classrooms = await connection.QueryAsync<ClassroomDirectoryItem>(sql, new { UserId = userId });
                return classrooms.ToList();
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to load your classrooms. Please check your database connection and try again.", exception);
            }
        }

        public async Task UnarchiveAsync(int userId, int classroomId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    UPDATE classrooms SET is_archived = FALSE
                    WHERE classroom_id = @ClassroomId AND owner_id = @UserId AND is_archived = TRUE;
                    """;
                int affected = await connection.ExecuteAsync(sql, new { UserId = userId, ClassroomId = classroomId });
                if (affected != 1)
                    throw new InvalidOperationException("This classroom is unavailable, already active, or you are not its owner.");
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to unarchive the classroom. Please check your database connection and try again.", exception);
            }
        }

        public async Task DeleteArchivedAsync(int userId, int classroomId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                await connection.OpenAsync();
                using MySqlTransaction transaction = await connection.BeginTransactionAsync();
                string sql = """
                    SELECT classroom_id FROM classrooms
                    WHERE classroom_id = @ClassroomId AND owner_id = @UserId AND is_archived = TRUE
                    FOR UPDATE;
                    """;
                int? allowed = await connection.QuerySingleOrDefaultAsync<int?>(sql, new { UserId = userId, ClassroomId = classroomId }, transaction);
                if (allowed == null)
                    throw new InvalidOperationException("Only the owner can permanently delete an archived classroom.");
                sql = """
                    DELETE likes FROM announcement_likes likes
                    INNER JOIN announcements a ON a.announcement_id = likes.announcement_id WHERE a.classroom_id = @ClassroomId;
                    DELETE FROM announcements WHERE classroom_id = @ClassroomId;
                    DELETE attachment FROM resource_attachments attachment
                    INNER JOIN resources r ON r.resource_id = attachment.resource_id WHERE r.classroom_id = @ClassroomId;
                    DELETE FROM resources WHERE classroom_id = @ClassroomId;
                    DELETE attachment FROM submission_attachments attachment
                    INNER JOIN submissions s ON s.submission_id = attachment.submission_id
                    INNER JOIN assignments a ON a.assignment_id = s.assignment_id WHERE a.classroom_id = @ClassroomId;
                    DELETE s FROM submissions s INNER JOIN assignments a ON a.assignment_id = s.assignment_id WHERE a.classroom_id = @ClassroomId;
                    DELETE attachment FROM assignment_attachments attachment
                    INNER JOIN assignments a ON a.assignment_id = attachment.assignment_id WHERE a.classroom_id = @ClassroomId;
                    DELETE FROM assignments WHERE classroom_id = @ClassroomId;
                    DELETE FROM classroom_invitations WHERE classroom_id = @ClassroomId;
                    DELETE FROM members WHERE classroom_id = @ClassroomId;
                    DELETE FROM classrooms WHERE classroom_id = @ClassroomId AND owner_id = @UserId AND is_archived = TRUE;
                    """;
                await connection.ExecuteAsync(sql, new { UserId = userId, ClassroomId = classroomId }, transaction);
                await transaction.CommitAsync();
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to delete the archived classroom. Please check your database connection and try again.", exception);
            }
        }

        public async Task ArchiveAsync(int userId, int classroomId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();

                string sql = """
                    UPDATE classrooms
                    SET is_archived = TRUE
                    WHERE classroom_id = @ClassroomId AND owner_id = @UserId
                      AND is_archived = FALSE;
                    """;

                int affected = await connection.ExecuteAsync(sql, new { ClassroomId = classroomId, UserId = userId });

                if (affected != 1) throw new InvalidOperationException("The classroom is already archived, unavailable, or you are not its owner.");
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to archive the classroom. Please check your database connection and try again.", exception);
            }
        }

        public async Task<Classroom> CreateAsync(Classroom classroom)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                await connection.OpenAsync();
                using MySqlTransaction transaction = await connection.BeginTransactionAsync();

                string sql = """
                    INSERT INTO classrooms (owner_id, name)
                    VALUES (@OwnerId, @Name);
                    SELECT classroom_id AS Id, owner_id AS OwnerId, name AS Name,
                           section AS Section, subject AS Subject, room AS Room,
                           schedule AS Schedule, level AS Level, join_code AS JoinCode,
                           is_archived AS IsArchived, created_at AS CreatedAt
                    FROM classrooms
                    WHERE classroom_id = LAST_INSERT_ID();
                    """;

                Classroom created = await connection.QuerySingleAsync<Classroom>(sql, new
                {
                    classroom.OwnerId,
                    classroom.Name
                }, transaction);

                string memberSql = """
                    INSERT INTO members (classroom_id, user_id, role)
                    VALUES (@ClassroomId, @UserId, 'Teacher');
                    """;

                await connection.ExecuteAsync(memberSql, new
                {
                    ClassroomId = created.Id,
                    UserId = created.OwnerId
                }, transaction);

                await transaction.CommitAsync();
                return created;
            }
            catch (MySqlException exception) when (exception.Number == 1062)
            {
                throw new InvalidOperationException("Unable to generate a unique class code. Please try again.", exception);
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to create the classroom. Please check your database connection and try again.", exception);
            }
        }

        public async Task<Classroom> JoinAsync(int userId, string joinCode)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                await connection.OpenAsync();
                using MySqlTransaction transaction = await connection.BeginTransactionAsync();

                string sql = """
                    SELECT classroom_id AS Id, owner_id AS OwnerId, name AS Name,
                           section AS Section, subject AS Subject, room AS Room,
                           schedule AS Schedule, level AS Level, join_code AS JoinCode,
                           is_archived AS IsArchived, created_at AS CreatedAt
                    FROM classrooms
                    WHERE join_code = @JoinCode
                    FOR UPDATE;
                    """;

                Classroom classroom = await connection.QuerySingleOrDefaultAsync<Classroom>(sql, new { JoinCode = joinCode }, transaction)
                    ?? throw new InvalidOperationException("No classroom was found with that code.");

                if (classroom.IsArchived) throw new InvalidOperationException("This classroom is archived and cannot be joined.");

                if (classroom.OwnerId == userId) throw new InvalidOperationException("You cannot join your own classroom.");

                string memberSql = """
                    SELECT COUNT(*) FROM members
                    WHERE classroom_id = @ClassroomId AND user_id = @UserId;
                    """;

                var parameters = new { ClassroomId = classroom.Id, UserId = userId };

                if (await connection.ExecuteScalarAsync<int>(memberSql, parameters, transaction) > 0)
                    throw new InvalidOperationException("You have already joined this classroom.");

                string insertSql = """
                    INSERT INTO members (classroom_id, user_id, role)
                    VALUES (@ClassroomId, @UserId, 'Student');
                    """;

                await connection.ExecuteAsync(insertSql, parameters, transaction);
                await transaction.CommitAsync();
                return classroom;
            }
            catch (MySqlException exception) when (exception.Number == 1062)
            {
                throw new InvalidOperationException("You have already joined this classroom.", exception);
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to join the classroom. Please check your database connection and try again.", exception);
            }
        }
    }
}
