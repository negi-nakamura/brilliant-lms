using brilliant_lms.Data;
using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using Dapper;
using MySql.Data.MySqlClient;

namespace brilliant_lms.Repositories
{
    public class AssignmentRepository
    {
        private SqlConnectionFactory factory = SqlConnectionFactory.Instance;

        public async Task<List<AssignmentDirectoryItem>> GetClassroomAssignmentsAsync(int userId, int classroomId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    SELECT a.assignment_id AS Id, a.classroom_id AS ClassroomId,
                           a.creator_id AS CreatorId, a.title AS Title, a.instructions AS Instructions,
                           a.due_at AS DueAt, a.max_points AS MaxPoints, a.created_at AS CreatedAt,
                           creator.first_name AS CreatorFirstName, creator.middle_name AS CreatorMiddleName,
                           creator.last_name AS CreatorLastName
                    FROM assignments a
                    INNER JOIN users creator ON creator.user_id = a.creator_id
                    INNER JOIN classrooms c ON c.classroom_id = a.classroom_id
                    WHERE a.classroom_id = @ClassroomId
                      AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members m
                          WHERE m.classroom_id = c.classroom_id AND m.user_id = @UserId))
                    ORDER BY a.created_at DESC, a.assignment_id DESC;

                    SELECT attachment.attachment_id AS AttachmentId, attachment.assignment_id AS AssignmentId,
                           attachment.file_name AS FileName, attachment.link_url AS LinkUrl, attachment.uploaded_at AS UploadedAt
                    FROM assignment_attachments attachment
                    INNER JOIN assignments a ON a.assignment_id = attachment.assignment_id
                    INNER JOIN classrooms c ON c.classroom_id = a.classroom_id
                    WHERE a.classroom_id = @ClassroomId
                      AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members m
                          WHERE m.classroom_id = c.classroom_id AND m.user_id = @UserId))
                    ORDER BY attachment.attachment_id;
                    """;
                using var results = await connection.QueryMultipleAsync(sql,
                    new { UserId = userId, ClassroomId = classroomId });
                List<AssignmentDirectoryItem> assignments = (await results.ReadAsync<AssignmentDirectoryItem>()).ToList();
                var attachments = (await results.ReadAsync<AssignmentAttachment>()).ToLookup(attachment => attachment.AssignmentId);
                foreach (AssignmentDirectoryItem assignment in assignments)
                {
                    assignment.Attachments = attachments[assignment.Id].ToList();
                }
                return assignments;
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to load assignments. Please check your database connection and try again.", exception);
            }
        }

        public async Task<Assignment> CreateAsync(Assignment assignment, List<string> attachmentLinks)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                await connection.OpenAsync();
                using MySqlTransaction transaction = await connection.BeginTransactionAsync();

                string permissionSql = """
                    SELECT c.classroom_id FROM classrooms c
                    WHERE c.classroom_id = @ClassroomId AND (c.owner_id = @CreatorId OR EXISTS (SELECT 1 FROM members teacher
                          WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @CreatorId AND teacher.role = 'Teacher')) AND c.is_archived = FALSE
                    FOR UPDATE;
                    """;
                int? classroomId = await connection.QuerySingleOrDefaultAsync<int?>(permissionSql,
                    new { assignment.ClassroomId, assignment.CreatorId }, transaction);
                if (classroomId == null)
                    throw new InvalidOperationException("This classroom is archived, unavailable, or you do not have teacher access.");

                string sql = """
                    INSERT INTO assignments (classroom_id, creator_id, title, instructions, due_at, max_points)
                    VALUES (@ClassroomId, @CreatorId, @Title, @Instructions, @DueAt, @MaxPoints);
                    SELECT LAST_INSERT_ID();
                    """;
                assignment.Id = await connection.QuerySingleAsync<int>(sql, assignment, transaction);

                int attachmentNumber = 1;
                foreach (string attachmentLink in attachmentLinks)
                {
                    string attachmentSql = """
                        INSERT INTO assignment_attachments (assignment_id, file_name, link_url)
                        VALUES (@AssignmentId, @FileName, @LinkUrl);
                        """;
                    await connection.ExecuteAsync(attachmentSql, new
                    {
                        AssignmentId = assignment.Id,
                        FileName = $"Attachment {attachmentNumber}",
                        LinkUrl = attachmentLink
                    }, transaction);
                    attachmentNumber++;
                }

                string selectSql = """
                    SELECT assignment_id AS Id, classroom_id AS ClassroomId, creator_id AS CreatorId,
                           title AS Title, instructions AS Instructions, due_at AS DueAt,
                           max_points AS MaxPoints, created_at AS CreatedAt
                    FROM assignments WHERE assignment_id = @Id;
                    """;
                Assignment saved = await connection.QuerySingleAsync<Assignment>(selectSql, new { assignment.Id }, transaction);
                await transaction.CommitAsync();
                return saved;
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to create the assignment. Please check your database connection and try again.", exception);
            }
        }

        public async Task<Assignment> UpdateAsync(Assignment assignment, List<string> attachmentLinks)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                await connection.OpenAsync();
                using MySqlTransaction transaction = await connection.BeginTransactionAsync();

                string permissionSql = """
                    SELECT a.assignment_id FROM assignments a
                    INNER JOIN classrooms c ON c.classroom_id = a.classroom_id
                    WHERE a.assignment_id = @Id AND a.classroom_id = @ClassroomId
                      AND (c.owner_id = @CreatorId OR EXISTS (SELECT 1 FROM members teacher
                          WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @CreatorId AND teacher.role = 'Teacher')) AND c.is_archived = FALSE
                    FOR UPDATE;
                    """;
                int? assignmentId = await connection.QuerySingleOrDefaultAsync<int?>(permissionSql,
                    new { assignment.Id, assignment.ClassroomId, assignment.CreatorId }, transaction);
                if (assignmentId == null)
                    throw new InvalidOperationException("This assignment is unavailable, archived, or you do not have permission to update it.");

                decimal highestScore = await connection.ExecuteScalarAsync<decimal>(
                    "SELECT COALESCE(MAX(score), 0) FROM submissions WHERE assignment_id = @Id;", new { assignment.Id }, transaction);
                if (assignment.MaxPoints < highestScore)
                    throw new InvalidOperationException("Maximum points cannot be lower than an existing student score.");

                string sql = """
                    UPDATE assignments SET title = @Title, instructions = @Instructions,
                        due_at = @DueAt, max_points = @MaxPoints WHERE assignment_id = @Id;
                    """;
                await connection.ExecuteAsync(sql, assignment, transaction);
                await connection.ExecuteAsync("DELETE FROM assignment_attachments WHERE assignment_id = @Id;",
                    new { assignment.Id }, transaction);

                int attachmentNumber = 1;
                foreach (string attachmentLink in attachmentLinks)
                {
                    string attachmentSql = """
                        INSERT INTO assignment_attachments (assignment_id, file_name, link_url)
                        VALUES (@AssignmentId, @FileName, @LinkUrl);
                        """;
                    await connection.ExecuteAsync(attachmentSql, new
                    {
                        AssignmentId = assignment.Id,
                        FileName = $"Attachment {attachmentNumber}",
                        LinkUrl = attachmentLink
                    }, transaction);
                    attachmentNumber++;
                }

                string selectSql = """
                    SELECT assignment_id AS Id, classroom_id AS ClassroomId, creator_id AS CreatorId,
                           title AS Title, instructions AS Instructions, due_at AS DueAt,
                           max_points AS MaxPoints, created_at AS CreatedAt
                    FROM assignments WHERE assignment_id = @Id;
                    """;
                Assignment saved = await connection.QuerySingleAsync<Assignment>(selectSql, new { assignment.Id }, transaction);
                await transaction.CommitAsync();
                return saved;
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to update the assignment. Please check your database connection and try again.", exception);
            }
        }

        public async Task DeleteAsync(int userId, int classroomId, int assignmentId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    DELETE a FROM assignments a
                    INNER JOIN classrooms c ON c.classroom_id = a.classroom_id
                    WHERE a.assignment_id = @AssignmentId AND a.classroom_id = @ClassroomId
                      AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members teacher
                          WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @UserId AND teacher.role = 'Teacher')) AND c.is_archived = FALSE;
                    """;
                int affected = await connection.ExecuteAsync(sql,
                    new { UserId = userId, ClassroomId = classroomId, AssignmentId = assignmentId });
                if (affected != 1)
                    throw new InvalidOperationException("This assignment is unavailable, archived, or you do not have permission to delete it.");
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to delete the assignment. Please check your database connection and try again.", exception);
            }
        }
    }
}
