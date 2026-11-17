using brilliant_lms.Data;
using brilliant_lms.Models.Entities;
using brilliant_lms.Models.Responses;
using Dapper;
using MySql.Data.MySqlClient;

namespace brilliant_lms.Repositories
{
    public class ResourceRepository
    {
        private SqlConnectionFactory factory = SqlConnectionFactory.Instance;

        public async Task<List<ResourceDirectoryItem>> GetClassroomResourcesAsync(int userId, int classroomId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    SELECT a.resource_id AS Id, a.classroom_id AS ClassroomId,
                           a.uploader_id AS UploaderId, a.title AS Title, a.description AS Description,
                           a.link_url AS LinkUrl, a.created_at AS CreatedAt,
                           creator.first_name AS CreatorFirstName, creator.middle_name AS CreatorMiddleName,
                           creator.last_name AS CreatorLastName
                    FROM resources a
                    INNER JOIN users creator ON creator.user_id = a.uploader_id
                    INNER JOIN classrooms c ON c.classroom_id = a.classroom_id
                    WHERE a.classroom_id = @ClassroomId
                      AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members m
                          WHERE m.classroom_id = c.classroom_id AND m.user_id = @UserId))
                    ORDER BY a.created_at DESC, a.resource_id DESC;

                    SELECT attachment.attachment_id AS AttachmentId, attachment.resource_id AS ResourceId,
                           attachment.file_name AS FileName, attachment.link_url AS LinkUrl, attachment.uploaded_at AS UploadedAt
                    FROM resource_attachments attachment
                    INNER JOIN resources a ON a.resource_id = attachment.resource_id
                    INNER JOIN classrooms c ON c.classroom_id = a.classroom_id
                    WHERE a.classroom_id = @ClassroomId
                      AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members m
                          WHERE m.classroom_id = c.classroom_id AND m.user_id = @UserId))
                    ORDER BY attachment.attachment_id;
                    """;
                using var results = await connection.QueryMultipleAsync(sql,
                    new { UserId = userId, ClassroomId = classroomId });
                List<ResourceDirectoryItem> resources = (await results.ReadAsync<ResourceDirectoryItem>()).ToList();
                var attachments = (await results.ReadAsync<ResourceAttachment>()).ToLookup(attachment => attachment.ResourceId);
                foreach (ResourceDirectoryItem resource in resources)
                {
                    resource.Attachments = attachments[resource.Id].ToList();
                    if (resource.Attachments.Count == 0 && !string.IsNullOrWhiteSpace(resource.LinkUrl))
                    {
                        ResourceAttachment attachment = new ResourceAttachment
                        {
                            ResourceId = resource.Id,
                            FileName = "Attachment 1",
                            LinkUrl = resource.LinkUrl
                        };
                        resource.Attachments.Add(attachment);
                    }
                }
                return resources;
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to load resources. Please check your database connection and try again.", exception);
            }
        }

        public async Task<Resource> CreateAsync(Resource resource, List<string> attachmentLinks)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                await connection.OpenAsync();
                using MySqlTransaction transaction = await connection.BeginTransactionAsync();

                string permissionSql = """
                    SELECT c.classroom_id FROM classrooms c
                    WHERE c.classroom_id = @ClassroomId AND (c.owner_id = @UploaderId OR EXISTS (SELECT 1 FROM members teacher
                          WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @UploaderId AND teacher.role = 'Teacher')) AND c.is_archived = FALSE
                    FOR UPDATE;
                    """;
                int? classroomId = await connection.QuerySingleOrDefaultAsync<int?>(permissionSql,
                    new { resource.ClassroomId, resource.UploaderId }, transaction);
                if (classroomId == null)
                    throw new InvalidOperationException("This classroom is archived, unavailable, or you do not have teacher access.");

                string sql = """
                    INSERT INTO resources (classroom_id, uploader_id, title, description, link_url)
                    VALUES (@ClassroomId, @UploaderId, @Title, @Description, @LinkUrl);
                    SELECT LAST_INSERT_ID();
                    """;
                resource.Id = await connection.QuerySingleAsync<int>(sql, resource, transaction);

                int attachmentNumber = 1;
                foreach (string attachmentLink in attachmentLinks)
                {
                    string attachmentSql = """
                        INSERT INTO resource_attachments (resource_id, file_name, link_url)
                        VALUES (@ResourceId, @FileName, @LinkUrl);
                        """;
                    await connection.ExecuteAsync(attachmentSql, new
                    {
                        ResourceId = resource.Id,
                        FileName = $"Attachment {attachmentNumber}",
                        LinkUrl = attachmentLink
                    }, transaction);
                    attachmentNumber++;
                }

                string selectSql = """
                    SELECT resource_id AS Id, classroom_id AS ClassroomId, uploader_id AS UploaderId,
                           title AS Title, description AS Description, link_url AS LinkUrl, created_at AS CreatedAt
                    FROM resources WHERE resource_id = @Id;
                    """;
                Resource saved = await connection.QuerySingleAsync<Resource>(selectSql, new { resource.Id }, transaction);
                await transaction.CommitAsync();
                return saved;
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to create the resource. Please check your database connection and try again.", exception);
            }
        }

        public async Task<Resource> UpdateAsync(Resource resource, List<string> attachmentLinks)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                await connection.OpenAsync();
                using MySqlTransaction transaction = await connection.BeginTransactionAsync();

                string permissionSql = """
                    SELECT a.resource_id FROM resources a
                    INNER JOIN classrooms c ON c.classroom_id = a.classroom_id
                    WHERE a.resource_id = @Id AND a.classroom_id = @ClassroomId
                      AND (c.owner_id = @UploaderId OR EXISTS (SELECT 1 FROM members teacher
                          WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @UploaderId AND teacher.role = 'Teacher')) AND c.is_archived = FALSE
                    FOR UPDATE;
                    """;
                int? resourceId = await connection.QuerySingleOrDefaultAsync<int?>(permissionSql,
                    new { resource.Id, resource.ClassroomId, resource.UploaderId }, transaction);
                if (resourceId == null)
                    throw new InvalidOperationException("This resource is unavailable, archived, or you do not have permission to update it.");

                string sql = """
                    UPDATE resources SET title = @Title, description = @Description,
                        link_url = @LinkUrl WHERE resource_id = @Id;
                    """;
                await connection.ExecuteAsync(sql, resource, transaction);
                await connection.ExecuteAsync("DELETE FROM resource_attachments WHERE resource_id = @Id;",
                    new { resource.Id }, transaction);

                int attachmentNumber = 1;
                foreach (string attachmentLink in attachmentLinks)
                {
                    string attachmentSql = """
                        INSERT INTO resource_attachments (resource_id, file_name, link_url)
                        VALUES (@ResourceId, @FileName, @LinkUrl);
                        """;
                    await connection.ExecuteAsync(attachmentSql, new
                    {
                        ResourceId = resource.Id,
                        FileName = $"Attachment {attachmentNumber}",
                        LinkUrl = attachmentLink
                    }, transaction);
                    attachmentNumber++;
                }

                string selectSql = """
                    SELECT resource_id AS Id, classroom_id AS ClassroomId, uploader_id AS UploaderId,
                           title AS Title, description AS Description, link_url AS LinkUrl, created_at AS CreatedAt
                    FROM resources WHERE resource_id = @Id;
                    """;
                Resource saved = await connection.QuerySingleAsync<Resource>(selectSql, new { resource.Id }, transaction);
                await transaction.CommitAsync();
                return saved;
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to update the resource. Please check your database connection and try again.", exception);
            }
        }

        public async Task DeleteAsync(int userId, int classroomId, int resourceId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                string sql = """
                    DELETE a FROM resources a
                    INNER JOIN classrooms c ON c.classroom_id = a.classroom_id
                    WHERE a.resource_id = @ResourceId AND a.classroom_id = @ClassroomId
                      AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members teacher
                          WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @UserId AND teacher.role = 'Teacher')) AND c.is_archived = FALSE;
                    """;
                int affected = await connection.ExecuteAsync(sql,
                    new { UserId = userId, ClassroomId = classroomId, ResourceId = resourceId });
                if (affected != 1)
                    throw new InvalidOperationException("This resource is unavailable, archived, or you do not have permission to delete it.");
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to delete the resource. Please check your database connection and try again.", exception);
            }
        }
    }
}
