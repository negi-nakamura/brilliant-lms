using brilliant_lms.Data;
using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using Dapper;
using MySql.Data.MySqlClient;

namespace brilliant_lms.Repositories
{
    public class ReportRepository
    {
        private SqlConnectionFactory factory = SqlConnectionFactory.Instance;

        public async Task<ClassroomReportData> GetClassroomReportAsync(int userId, int classroomId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    SELECT c.classroom_id FROM classrooms c
                    WHERE c.classroom_id = @ClassroomId AND (c.owner_id = @UserId OR EXISTS (
                        SELECT 1 FROM members teacher WHERE teacher.classroom_id = c.classroom_id
                        AND teacher.user_id = @UserId AND teacher.role = 'Teacher'));

                    SELECT a.assignment_id AS Id, a.classroom_id AS ClassroomId, a.creator_id AS CreatorId,
                           a.title AS Title, a.instructions AS Instructions, a.due_at AS DueAt,
                           a.max_points AS MaxPoints, a.created_at AS CreatedAt
                    FROM assignments a INNER JOIN classrooms c ON c.classroom_id = a.classroom_id
                    WHERE c.classroom_id = @ClassroomId AND (c.owner_id = @UserId OR EXISTS (
                        SELECT 1 FROM members teacher WHERE teacher.classroom_id = c.classroom_id
                        AND teacher.user_id = @UserId AND teacher.role = 'Teacher'))
                    ORDER BY a.created_at DESC, a.assignment_id DESC;

                    SELECT m.member_id AS Id, m.classroom_id AS ClassroomId, m.user_id AS UserId,
                           m.role AS Role, m.joined_at AS JoinedAt, u.first_name AS FirstName,
                           u.middle_name AS MiddleName, u.last_name AS LastName, u.email AS Email
                    FROM members m INNER JOIN users u ON u.user_id = m.user_id
                    INNER JOIN classrooms c ON c.classroom_id = m.classroom_id
                    WHERE c.classroom_id = @ClassroomId AND m.role = 'Student'
                      AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members teacher
                        WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @UserId AND teacher.role = 'Teacher'))
                    ORDER BY u.last_name, u.first_name, m.member_id;

                    SELECT s.submission_id AS Id, s.assignment_id AS AssignmentId, s.student_id AS StudentId,
                           s.submitted_at AS SubmittedAt, s.score AS Score, s.graded_at AS GradedAt,
                           s.graded_by_id AS GradedById, s.returned_at AS ReturnedAt
                    FROM submissions s INNER JOIN assignments a ON a.assignment_id = s.assignment_id
                    INNER JOIN classrooms c ON c.classroom_id = a.classroom_id
                    INNER JOIN members m ON m.classroom_id = c.classroom_id AND m.user_id = s.student_id AND m.role = 'Student'
                    WHERE c.classroom_id = @ClassroomId AND (c.owner_id = @UserId OR EXISTS (
                        SELECT 1 FROM members teacher WHERE teacher.classroom_id = c.classroom_id
                        AND teacher.user_id = @UserId AND teacher.role = 'Teacher'));
                    """;
                using SqlMapper.GridReader results = await connection.QueryMultipleAsync(sql, new { UserId = userId, ClassroomId = classroomId });
                int? allowed = await results.ReadSingleOrDefaultAsync<int?>();
                if (allowed == null) throw new InvalidOperationException("This classroom is unavailable or you do not have teacher access to its reports.");
                ClassroomReportData data = new ClassroomReportData
                {
                    Assignments = (await results.ReadAsync<Assignment>()).ToList(),
                    Students = (await results.ReadAsync<MemberDirectoryItem>()).ToList(),
                    Submissions = (await results.ReadAsync<Submission>()).ToList()
                };
                return data;
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to load classroom reports. Please check your database connection and try again.", exception);
            }
        }
    }
}
