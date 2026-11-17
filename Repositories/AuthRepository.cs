using brilliant_lms.Data;
using brilliant_lms.Models.Entities;
using Dapper;
using MySql.Data.MySqlClient;

namespace brilliant_lms.Repositories
{
    public class AuthRepository
    {
        SqlConnectionFactory factory = SqlConnectionFactory.Instance;

        public async Task<User> RegisterAsync(User user)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();

                string sql = """
                    INSERT INTO users (first_name, middle_name, last_name, email, password)
                    VALUES (@FirstName, @MiddleName, @LastName, @Email, @Password);
                    SELECT user_id AS Id, first_name AS FirstName, middle_name AS MiddleName, last_name AS LastName, email AS Email, created_at AS CreatedAt
                    FROM users WHERE user_id = LAST_INSERT_ID();
                    """;

                return await connection.QuerySingleAsync<User>(sql, new
                {
                    user.FirstName,
                    user.MiddleName,
                    user.LastName,
                    user.Email,
                    user.Password
                });
            }
            catch (MySqlException exception) when (exception.Number == 1062)
            {
                throw new InvalidOperationException("This email is already registered.", exception);
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to create your account. Please check your database connection and try again.", exception);
            }
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();

                string sql = """
                    SELECT user_id AS Id, first_name AS FirstName,
                           middle_name AS MiddleName, last_name AS LastName,
                           email AS Email, created_at AS CreatedAt
                    FROM users WHERE email = @Email AND password = @Password;
                    """;

                return await connection.QuerySingleOrDefaultAsync<User>(sql, new { Email = email, Password = password })
                    ?? throw new InvalidOperationException("The email or password is incorrect.");
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to log in. Please check your database connection and try again.", exception);
            }
        }


        public async Task ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            try
            {
                using MySqlConnection connection = factory.CreateConnection();

                string sql = """
                    UPDATE users
                    SET password = @NewPassword
                    WHERE user_id = @UserId
                      AND CAST(password AS BINARY) = CAST(@CurrentPassword AS BINARY);
                    """;

                int affected = await connection.ExecuteAsync(sql, new
                {
                    UserId = userId,
                    CurrentPassword = currentPassword,
                    NewPassword = newPassword
                });

                if (affected != 1) throw new InvalidOperationException("The current password is incorrect.");
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException(
                    "Unable to change your password. Please check your database connection and try again.", exception);
            }
        }
    }
}
