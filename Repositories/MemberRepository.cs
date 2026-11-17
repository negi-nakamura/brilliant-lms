using brilliant_lms.Data;
using brilliant_lms.Models.Responses;
using Dapper;
using MySql.Data.MySqlClient;

namespace brilliant_lms.Repositories
{
    public class MemberRepository
    {
        private SqlConnectionFactory factory = SqlConnectionFactory.Instance;

        public async Task<List<MemberDirectoryItem>> GetClassroomMembersAsync(int userId, int classroomId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    SELECT m.member_id AS Id, m.classroom_id AS ClassroomId, m.user_id AS UserId,
                           m.role AS Role, m.joined_at AS JoinedAt, u.first_name AS FirstName,
                           u.middle_name AS MiddleName, u.last_name AS LastName, u.email AS Email
                    FROM members m
                    INNER JOIN users u ON u.user_id = m.user_id
                    INNER JOIN classrooms c ON c.classroom_id = m.classroom_id
                    WHERE m.classroom_id = @ClassroomId AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members viewer
                          WHERE viewer.classroom_id = c.classroom_id AND viewer.user_id = @UserId))
                    ORDER BY CASE WHEN m.user_id = c.owner_id THEN 0 ELSE 1 END, u.last_name, u.first_name, m.member_id;
                    """;
                var members = await connection.QueryAsync<MemberDirectoryItem>(sql, new { UserId = userId, ClassroomId = classroomId });
                return members.ToList();
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to load classroom members. Please check your database connection and try again.", exception);
            }
        }

        public async Task RemoveAsync(int userId, int classroomId, int memberId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    DELETE m FROM members m
                    INNER JOIN classrooms c ON c.classroom_id = m.classroom_id
                    LEFT JOIN members teacher ON teacher.classroom_id = c.classroom_id
                        AND teacher.user_id = @UserId AND teacher.role = 'Teacher'
                    WHERE m.member_id = @MemberId AND m.classroom_id = @ClassroomId
                      AND (c.owner_id = @UserId OR teacher.member_id IS NOT NULL)
                      AND m.user_id <> c.owner_id AND c.is_archived = FALSE;
                    """;
                int affected = await connection.ExecuteAsync(sql, new { UserId = userId, ClassroomId = classroomId, MemberId = memberId });
                if (affected != 1)
                    throw new InvalidOperationException("This member is unavailable, the classroom is archived, or you do not have permission to remove them.");
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to remove the member. Please check your database connection and try again.", exception);
            }
        }
    }
}
