using brilliant_lms.Data;
using brilliant_lms.Models.Entities;
using Dapper;
using brilliant_lms.Models.Responses;
using MySql.Data.MySqlClient;

namespace brilliant_lms.Repositories
{
    public class AnnouncementRepository
    {
        private SqlConnectionFactory factory = SqlConnectionFactory.Instance;

        public async Task<List<AnnouncementDirectoryItem>> GetClassroomAnnouncementsAsync(int userId, int classroomId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();

                string sql = """
                    SELECT a.announcement_id AS Id, a.classroom_id AS ClassroomId,
                           a.author_id AS AuthorId, a.content AS Content, a.created_at AS CreatedAt,
                           creator.first_name AS CreatorFirstName,
                           creator.middle_name AS CreatorMiddleName,
                           creator.last_name AS CreatorLastName,
                           EXISTS (SELECT 1 FROM announcement_likes current_like
                               WHERE current_like.announcement_id = a.announcement_id
                                 AND current_like.user_id = @UserId) AS LikedByCurrentUser,
                           (SELECT COUNT(*) FROM announcement_likes likes
                            WHERE likes.announcement_id = a.announcement_id) AS LikeCount
                    FROM announcements a
                    INNER JOIN users creator ON creator.user_id = a.author_id
                    INNER JOIN classrooms c ON c.classroom_id = a.classroom_id
                    WHERE a.classroom_id = @ClassroomId
                      AND (c.owner_id = @UserId OR EXISTS (
                          SELECT 1 FROM members m
                          WHERE m.classroom_id = c.classroom_id AND m.user_id = @UserId))
                    ORDER BY a.created_at DESC, a.announcement_id DESC;
                    """;

                var announcements = await connection.QueryAsync<AnnouncementDirectoryItem>(sql, new { UserId = userId, ClassroomId = classroomId });
                return announcements.ToList();
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to load announcements. Please check your database connection and try again.", exception);
            }
        }

        public async Task<AnnouncementLikeState> SetLikeAsync(int userId, int announcementId, bool liked)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                await connection.OpenAsync();
                using MySqlTransaction transaction = await connection.BeginTransactionAsync();

                string permissionSql = """
                    SELECT a.announcement_id
                    FROM announcements a
                    INNER JOIN classrooms c ON c.classroom_id = a.classroom_id
                    WHERE a.announcement_id = @AnnouncementId AND c.is_archived = FALSE
                      AND EXISTS (SELECT 1 FROM members m
                          WHERE m.classroom_id = c.classroom_id AND m.user_id = @UserId
                            AND m.role = 'Student')
                    FOR UPDATE;
                    """;
                var parameters = new { UserId = userId, AnnouncementId = announcementId };

                int? id = await connection.QuerySingleOrDefaultAsync<int?>(permissionSql, parameters, transaction);
                
                if (id == null) throw new InvalidOperationException("This announcement is unavailable or you are no longer a student in this active classroom.");

                string sql;

                if (liked)
                {
                    sql = """
                        INSERT INTO announcement_likes (announcement_id, user_id)
                        SELECT @AnnouncementId, @UserId
                        WHERE NOT EXISTS (SELECT 1 FROM announcement_likes
                            WHERE announcement_id = @AnnouncementId AND user_id = @UserId);
                        """;
                }
                else
                {
                    sql = """
                        DELETE FROM announcement_likes
                        WHERE announcement_id = @AnnouncementId AND user_id = @UserId;
                        """;
                }

                await connection.ExecuteAsync(sql, parameters, transaction);

                string stateSql = """
                    SELECT COUNT(*) AS LikeCount,
                           EXISTS (SELECT 1 FROM announcement_likes
                               WHERE announcement_id = @AnnouncementId AND user_id = @UserId) AS LikedByCurrentUser
                    FROM announcement_likes WHERE announcement_id = @AnnouncementId;
                    """;
                
                AnnouncementLikeState state = await connection.QuerySingleAsync<AnnouncementLikeState>(stateSql, parameters, transaction);
                await transaction.CommitAsync();
                return state;
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to update your like. Please check your database connection and try again.", exception);
            }
        }

        public async Task<Announcement> UpdateAsync(Announcement announcement)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();

                string sql = """
                    UPDATE announcements a
                    INNER JOIN classrooms c ON c.classroom_id = a.classroom_id
                    SET a.content = @Content
                    WHERE a.announcement_id = @Id AND a.classroom_id = @ClassroomId
                      AND (c.owner_id = @AuthorId OR EXISTS (SELECT 1 FROM members teacher
                          WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @AuthorId AND teacher.role = 'Teacher'))
                      AND c.is_archived = FALSE;

                    SELECT a.announcement_id AS Id, a.classroom_id AS ClassroomId,
                           a.author_id AS AuthorId, a.content AS Content, a.created_at AS CreatedAt
                    FROM announcements a
                    INNER JOIN classrooms c ON c.classroom_id = a.classroom_id
                    WHERE a.announcement_id = @Id AND a.classroom_id = @ClassroomId
                      AND (c.owner_id = @AuthorId OR EXISTS (SELECT 1 FROM members teacher
                          WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @AuthorId AND teacher.role = 'Teacher'))
                      AND c.is_archived = FALSE;
                    """;

                return await connection.QuerySingleOrDefaultAsync<Announcement>(sql, new
                {
                    announcement.Id,
                    announcement.ClassroomId,
                    announcement.AuthorId,
                    announcement.Content
                }) ?? throw new InvalidOperationException("The announcement is unavailable, archived, or you do not have permission to update it.");
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to update the announcement. Please check your database connection and try again.", exception);
            }
        }

        public async Task DeleteAsync(int userId, int classroomId, int announcementId)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();

                string sql = """
                    DELETE a FROM announcements a
                    INNER JOIN classrooms c ON c.classroom_id = a.classroom_id
                    WHERE a.announcement_id = @AnnouncementId AND a.classroom_id = @ClassroomId
                      AND (c.owner_id = @UserId OR EXISTS (SELECT 1 FROM members teacher
                          WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @UserId AND teacher.role = 'Teacher'))
                      AND c.is_archived = FALSE;
                    """;

                int affected = await connection.ExecuteAsync(sql, new
                {
                    UserId = userId,
                    ClassroomId = classroomId,
                    AnnouncementId = announcementId
                });
                
                if (affected != 1) throw new InvalidOperationException("The announcement is unavailable, archived, or you do not have permission to delete it.");
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to delete the announcement. Please check your database connection and try again.", exception);
            }
        }

        public async Task<Announcement> CreateAsync(Announcement announcement)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();
                await connection.OpenAsync();

                string sql = """
                    INSERT INTO announcements (classroom_id, author_id, content)
                    SELECT c.classroom_id, @AuthorId, @Content
                    FROM classrooms c
                    WHERE c.classroom_id = @ClassroomId AND (c.owner_id = @AuthorId OR EXISTS (SELECT 1 FROM members teacher
                          WHERE teacher.classroom_id = c.classroom_id AND teacher.user_id = @AuthorId AND teacher.role = 'Teacher'))
                      AND c.is_archived = FALSE;
                    """;

                int affected = await connection.ExecuteAsync(sql, new
                {
                    announcement.ClassroomId,
                    announcement.AuthorId,
                    announcement.Content
                });

                if (affected != 1) throw new InvalidOperationException("This classroom is archived, unavailable, or you do not have teacher access.");

                string selectSql = """
                    SELECT announcement_id AS Id, classroom_id AS ClassroomId,
                           author_id AS AuthorId, content AS Content, created_at AS CreatedAt
                    FROM announcements WHERE announcement_id = LAST_INSERT_ID();
                    """;

                return await connection.QuerySingleAsync<Announcement>(selectSql);
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to create the announcement. Please check your database connection and try again.", exception);
            }
        }
    }
}
