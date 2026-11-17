using brilliant_lms.Data;
using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Requests;
using brilliant_lms.Models.Responses;
using Dapper;
using MySql.Data.MySqlClient;

namespace brilliant_lms.Repositories
{
    public class SubmissionRepository
    {
        private SqlConnectionFactory factory = SqlConnectionFactory.Instance;

        public async Task<List<SubmissionDirectoryItem>> GetAssignmentSubmissionsAsync(int userId, int assignmentId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    SELECT COALESCE(s.submission_id, 0) AS Id, a.assignment_id AS AssignmentId,
                           u.user_id AS StudentId, u.first_name AS StudentFirstName, u.middle_name AS StudentMiddleName,
                           u.last_name AS StudentLastName, u.email AS Email, s.answer_text AS AnswerText,
                           s.submitted_at AS SubmittedAt, s.score AS Score, s.feedback AS Feedback,
                           s.graded_by_id AS GradedById, s.graded_at AS GradedAt, s.returned_at AS ReturnedAt
                    FROM assignments a
                    JOIN classrooms c ON c.classroom_id = a.classroom_id
                    JOIN members m ON m.classroom_id = c.classroom_id AND m.role = 'Student'
                    JOIN users u ON u.user_id = m.user_id
                    LEFT JOIN submissions s ON s.assignment_id = a.assignment_id AND s.student_id = u.user_id
                    WHERE a.assignment_id = @AssignmentId AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members teacher
                          WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @UserId AND teacher.role = 'Teacher'))
                    ORDER BY u.last_name, u.first_name;
                    SELECT sa.attachment_id AS AttachmentId, sa.submission_id AS SubmissionId,
                           sa.file_name AS FileName, sa.link_url AS LinkUrl, sa.uploaded_at AS UploadedAt
                    FROM submission_attachments sa
                    JOIN submissions s ON s.submission_id = sa.submission_id
                    JOIN assignments a ON a.assignment_id = s.assignment_id
                    JOIN classrooms c ON c.classroom_id = a.classroom_id
                    WHERE a.assignment_id = @AssignmentId AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members teacher
                          WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @UserId AND teacher.role = 'Teacher'))
                    ORDER BY sa.attachment_id;
                    """;
                using SqlMapper.GridReader results = await connection.QueryMultipleAsync(sql, new { UserId = userId, AssignmentId = assignmentId });
                List<SubmissionDirectoryItem> submissions = (await results.ReadAsync<SubmissionDirectoryItem>()).ToList();
                List<SubmissionAttachment> attachments = (await results.ReadAsync<SubmissionAttachment>()).ToList();
                ILookup<int, SubmissionAttachment> attachmentLookup = attachments.ToLookup(attachment => attachment.SubmissionId);
                foreach (SubmissionDirectoryItem submission in submissions)
                    submission.Attachments = attachmentLookup[submission.Id].ToList();
                return submissions;
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to load student work. Please try again.", exception);
            }
        }

        public async Task<SubmissionDirectoryItem> GetStudentSubmissionAsync(int userId, int assignmentId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    SELECT a.assignment_id AS AssignmentId, COALESCE(s.submission_id, 0) AS Id,
                           @UserId AS StudentId, s.answer_text AS AnswerText, s.submitted_at AS SubmittedAt,
                           s.score AS Score, s.feedback AS Feedback, s.graded_at AS GradedAt,
                           s.graded_by_id AS GradedById, s.returned_at AS ReturnedAt
                    FROM assignments a
                    JOIN members m ON m.classroom_id = a.classroom_id AND m.user_id = @UserId AND m.role = 'Student'
                    LEFT JOIN submissions s ON s.assignment_id = a.assignment_id AND s.student_id = @UserId
                    WHERE a.assignment_id = @AssignmentId;
                    """;
                SubmissionDirectoryItem submission = await connection.QuerySingleOrDefaultAsync<SubmissionDirectoryItem>(sql,
                    new { UserId = userId, AssignmentId = assignmentId })
                    ?? throw new InvalidOperationException("This assignment is unavailable or you are no longer a student in this class.");
                sql = """
                    SELECT attachment_id AS AttachmentId, submission_id AS SubmissionId,
                           file_name AS FileName, link_url AS LinkUrl, uploaded_at AS UploadedAt
                    FROM submission_attachments WHERE submission_id = @Id ORDER BY attachment_id;
                    """;
                submission.Attachments = (await connection.QueryAsync<SubmissionAttachment>(sql, new { submission.Id })).ToList();
                return submission;
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to load your submission. Please try again.", exception);
            }
        }

        public async Task SubmitAsync(int userId, int assignmentId, SubmitAssignmentRequest request)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                await connection.OpenAsync();
                using MySqlTransaction transaction = await connection.BeginTransactionAsync();
                string sql = """
                    SELECT a.assignment_id FROM assignments a
                    JOIN classrooms c ON c.classroom_id = a.classroom_id
                    JOIN members m ON m.classroom_id = c.classroom_id AND m.user_id = @UserId AND m.role = 'Student'
                    WHERE a.assignment_id = @AssignmentId AND c.is_archived = FALSE FOR UPDATE;
                    """;
                int? allowed = await connection.QuerySingleOrDefaultAsync<int?>(sql, new { UserId = userId, AssignmentId = assignmentId }, transaction);
                if (allowed == null) throw new InvalidOperationException("This class is archived or you are no longer a student in this class.");
                sql = """
                    SELECT submission_id AS Id, submitted_at AS SubmittedAt, returned_at AS ReturnedAt
                    FROM submissions WHERE assignment_id = @AssignmentId AND student_id = @UserId FOR UPDATE;
                    """;
                Submission? previous = await connection.QuerySingleOrDefaultAsync<Submission>(sql, new { UserId = userId, AssignmentId = assignmentId }, transaction);
                if (previous?.SubmittedAt != null && previous.ReturnedAt == null)
                    throw new InvalidOperationException("This assignment has already been turned in. Wait for your teacher to return it before submitting again.");
                int submissionId;
                if (previous == null)
                {
                    sql = """
                        INSERT INTO submissions (assignment_id, student_id, answer_text, submitted_at)
                        VALUES (@AssignmentId, @UserId, @AnswerText, CURRENT_TIMESTAMP);
                        SELECT LAST_INSERT_ID();
                        """;
                    submissionId = await connection.QuerySingleAsync<int>(sql, new { AssignmentId = assignmentId, UserId = userId, request.AnswerText }, transaction);
                }
                else
                {
                    submissionId = previous.Id;
                    sql = """
                        UPDATE submissions SET answer_text = @AnswerText, submitted_at = CURRENT_TIMESTAMP,
                            score = NULL, feedback = NULL, graded_by_id = NULL, graded_at = NULL, returned_at = NULL
                        WHERE submission_id = @SubmissionId;
                        DELETE FROM submission_attachments WHERE submission_id = @SubmissionId;
                        """;
                    await connection.ExecuteAsync(sql, new { SubmissionId = submissionId, request.AnswerText }, transaction);
                }
                int number = 1;
                foreach (string link in request.AttachmentLinks)
                {
                    sql = """
                        INSERT INTO submission_attachments (submission_id, file_name, link_url)
                        VALUES (@SubmissionId, @FileName, @LinkUrl);
                        """;
                    await connection.ExecuteAsync(sql, new { SubmissionId = submissionId, FileName = $"Attachment {number}", LinkUrl = link }, transaction);
                    number++;
                }
                await transaction.CommitAsync();
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to submit your assignment. Please try again.", exception);
            }
        }

        public async Task GradeAsync(int userId, int assignmentId, int submissionId, GradeSubmissionRequest request)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                await connection.OpenAsync();
                using MySqlTransaction transaction = await connection.BeginTransactionAsync();
                string sql = """
                    SELECT a.max_points FROM submissions s
                    JOIN assignments a ON a.assignment_id = s.assignment_id
                    JOIN classrooms c ON c.classroom_id = a.classroom_id
                    WHERE s.submission_id = @SubmissionId AND a.assignment_id = @AssignmentId
                      AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members teacher
                          WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @UserId AND teacher.role = 'Teacher')) AND c.is_archived = FALSE AND s.submitted_at IS NOT NULL
                      AND EXISTS (SELECT 1 FROM members m WHERE m.classroom_id = c.classroom_id
                                  AND m.user_id = s.student_id AND m.role = 'Student')
                    FOR UPDATE;
                    """;
                decimal? maxPoints = await connection.QuerySingleOrDefaultAsync<decimal?>(sql,
                    new { UserId = userId, AssignmentId = assignmentId, SubmissionId = submissionId }, transaction);
                if (maxPoints == null)
                    throw new InvalidOperationException("This work has not been turned in or is no longer available for grading.");
                if (request.Score > maxPoints)
                    throw new InvalidOperationException($"The grade cannot exceed {maxPoints:0.##} points.");
                sql = """
                    UPDATE submissions SET score = @Score, feedback = @Feedback,
                        graded_by_id = CASE WHEN @Score IS NULL THEN NULL ELSE @UserId END,
                        graded_at = CASE WHEN @Score IS NULL THEN NULL ELSE CURRENT_TIMESTAMP END,
                        returned_at = CASE WHEN @ReturnWork THEN CURRENT_TIMESTAMP ELSE NULL END
                    WHERE submission_id = @SubmissionId;
                    """;
                await connection.ExecuteAsync(sql, new { SubmissionId = submissionId, UserId = userId, request.Score, request.Feedback, request.ReturnWork }, transaction);
                await transaction.CommitAsync();
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to save student work. Please try again.", exception);
            }
        }
    }
}
