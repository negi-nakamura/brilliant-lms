using brilliant_lms.Utilities;
using Dapper;
using MySql.Data.MySqlClient;

namespace brilliant_lms.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            string connectionString = AppSettings.GetConnectionString();

            EnsureDatabaseExists(connectionString);
            EnsureTablesExist(connectionString);
        }

        private static void EnsureDatabaseExists(string connectionString)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder(connectionString);
            string database = builder.Database;
            builder.Database = string.Empty;

            using MySqlConnection connection = new MySqlConnection(builder.ToString());
            connection.Execute($"CREATE DATABASE IF NOT EXISTS `{database}`");
        }

        private static void EnsureTablesExist(string connectionString)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);

            foreach (string statement in GetSchemaStatements())
            {
                connection.Execute(statement);
            }
        }

        private static List<string> GetSchemaStatements()
        {
            return
            [
                """
                CREATE TABLE IF NOT EXISTS users (
                    user_id INT PRIMARY KEY AUTO_INCREMENT,
                    first_name VARCHAR(120) NOT NULL,
                    middle_name VARCHAR(120),
                    last_name VARCHAR(120) NOT NULL,
                    email VARCHAR(255) NOT NULL UNIQUE,
                    password VARCHAR(255) NOT NULL,
                    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
                )
                """,
                """
                CREATE TABLE IF NOT EXISTS classrooms (
                    classroom_id INT PRIMARY KEY AUTO_INCREMENT,
                    owner_id INT NOT NULL,
                    name VARCHAR(150) NOT NULL,
                    section VARCHAR(100),
                    subject VARCHAR(150),
                    room VARCHAR(100),
                    schedule VARCHAR(200),
                    level VARCHAR(100),
                    join_code VARCHAR(12) NOT NULL UNIQUE DEFAULT (UPPER(LEFT(REPLACE(UUID(), '-', ''), 12))),
                    is_archived BOOLEAN NOT NULL DEFAULT FALSE,
                    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

                    FOREIGN KEY (owner_id) REFERENCES users(user_id)
                )
                """,
                """
                CREATE TABLE IF NOT EXISTS members (
                    member_id INT PRIMARY KEY AUTO_INCREMENT,
                    classroom_id INT NOT NULL,
                    user_id INT NOT NULL,
                    role VARCHAR(10) NOT NULL CHECK (role IN ('Teacher', 'Student')),
                    joined_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

                    UNIQUE (classroom_id, user_id),
                    FOREIGN KEY (classroom_id) REFERENCES classrooms(classroom_id) ON DELETE CASCADE,
                    FOREIGN KEY (user_id) REFERENCES users(user_id)
                )
                """,
                """
                CREATE TABLE IF NOT EXISTS classroom_invitations (
                    invitation_id INT PRIMARY KEY AUTO_INCREMENT,
                    classroom_id INT NOT NULL,
                    inviter_id INT NOT NULL,
                    invitee_id INT NOT NULL,
                    role VARCHAR(10) NOT NULL CHECK (role IN ('Teacher', 'Student')),
                    status VARCHAR(10) NOT NULL DEFAULT 'Pending' CHECK (status IN ('Pending', 'Accepted', 'Declined')),
                    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
                    responded_at TIMESTAMP NULL,

                    INDEX ix_invitations_inbox (invitee_id, status),
                    INDEX ix_invitations_classroom (classroom_id, invitee_id, status),
                    FOREIGN KEY (classroom_id) REFERENCES classrooms(classroom_id) ON DELETE CASCADE,
                    FOREIGN KEY (inviter_id) REFERENCES users(user_id),
                    FOREIGN KEY (invitee_id) REFERENCES users(user_id)
                )
                """,
                """
                CREATE TABLE IF NOT EXISTS announcements (
                    announcement_id INT PRIMARY KEY AUTO_INCREMENT,
                    classroom_id INT NOT NULL,
                    author_id INT NOT NULL,
                    content TEXT NOT NULL,
                    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

                    FOREIGN KEY (classroom_id) REFERENCES classrooms(classroom_id) ON DELETE CASCADE,
                    FOREIGN KEY (author_id) REFERENCES users(user_id)
                )
                """,
                """
                CREATE TABLE IF NOT EXISTS announcement_likes (
                    announcement_id INT NOT NULL,
                    user_id INT NOT NULL,

                    PRIMARY KEY (announcement_id, user_id),
                    FOREIGN KEY (announcement_id) REFERENCES announcements(announcement_id) ON DELETE CASCADE,
                    FOREIGN KEY (user_id) REFERENCES users(user_id)
                )
                """,
                """
                CREATE TABLE IF NOT EXISTS resources (
                    resource_id INT PRIMARY KEY AUTO_INCREMENT,
                    classroom_id INT NOT NULL,
                    uploader_id INT NOT NULL,
                    title VARCHAR(200) NOT NULL,
                    description TEXT NULL,
                    link_url VARCHAR(2000) NOT NULL,
                    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

                    FOREIGN KEY (classroom_id) REFERENCES classrooms(classroom_id) ON DELETE CASCADE,
                    FOREIGN KEY (uploader_id) REFERENCES users(user_id)
                )
                """,
                """
                CREATE TABLE IF NOT EXISTS resource_attachments (
                    attachment_id INT PRIMARY KEY AUTO_INCREMENT,
                    resource_id INT NOT NULL,
                    file_name VARCHAR(255) NOT NULL,
                    link_url VARCHAR(2000) NOT NULL,
                    uploaded_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

                    FOREIGN KEY (resource_id) REFERENCES resources(resource_id) ON DELETE CASCADE
                )
                """,
                """
                CREATE TABLE IF NOT EXISTS assignments (
                    assignment_id INT PRIMARY KEY AUTO_INCREMENT,
                    classroom_id INT NOT NULL,
                    creator_id INT NOT NULL,
                    title VARCHAR(200) NOT NULL,
                    instructions TEXT NULL,
                    due_at TIMESTAMP NULL,
                    max_points DECIMAL(10,2) NOT NULL DEFAULT 100 CHECK (max_points > 0),
                    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

                    FOREIGN KEY (classroom_id) REFERENCES classrooms(classroom_id) ON DELETE CASCADE,
                    FOREIGN KEY (creator_id) REFERENCES users(user_id)
                )
                """,
                """
                CREATE TABLE IF NOT EXISTS assignment_attachments (
                    attachment_id INT PRIMARY KEY AUTO_INCREMENT,
                    assignment_id INT NOT NULL,
                    file_name VARCHAR(255) NOT NULL,
                    link_url VARCHAR(2000) NOT NULL,
                    uploaded_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

                    FOREIGN KEY (assignment_id) REFERENCES assignments(assignment_id) ON DELETE CASCADE
                )
                """,
                """
                CREATE TABLE IF NOT EXISTS submissions (
                    submission_id INT PRIMARY KEY AUTO_INCREMENT,
                    assignment_id INT NOT NULL,
                    student_id INT NOT NULL,
                    answer_text TEXT NULL,
                    submitted_at TIMESTAMP NULL,
                    score DECIMAL(10,2) NULL CHECK (score >= 0),
                    feedback TEXT NULL,
                    graded_by_id INT NULL,
                    graded_at TIMESTAMP NULL,
                    returned_at TIMESTAMP NULL,

                    UNIQUE (assignment_id, student_id),
                    FOREIGN KEY (assignment_id) REFERENCES assignments(assignment_id) ON DELETE CASCADE,
                    FOREIGN KEY (student_id) REFERENCES users(user_id),
                    FOREIGN KEY (graded_by_id) REFERENCES users(user_id)
                )
                """,
                """
                CREATE TABLE IF NOT EXISTS submission_attachments (
                    attachment_id INT PRIMARY KEY AUTO_INCREMENT,
                    submission_id INT NOT NULL,
                    file_name VARCHAR(255) NOT NULL,
                    link_url VARCHAR(2000) NOT NULL,
                    uploaded_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

                    FOREIGN KEY (submission_id) REFERENCES submissions(submission_id) ON DELETE CASCADE
                )
                """
            ];
        }
    }
}