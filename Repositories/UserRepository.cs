using brilliant_lms.Data;
using brilliant_lms.Models.Entities;
using MySql.Data.MySqlClient;
using Dapper;

namespace brilliant_lms.Repositories
{
    public class UserRepository
    {
        SqlConnectionFactory factory = SqlConnectionFactory.Instance;

        public async Task<User> UpdateInformationAsync(User user)
        {

            try
            {
                using MySqlConnection connection = factory.CreateConnection();

                string sql = """
                    UPDATE users
                    SET first_name = @FirstName,
                        middle_name = @MiddleName,
                        last_name = @LastName,
                        email = @Email
                    WHERE user_id = @Id;
                    SELECT user_id AS Id,
                           first_name AS FirstName,
                           middle_name AS MiddleName,
                           last_name AS LastName,
                           email AS Email,
                           created_at AS CreatedAt
                    FROM users
                    WHERE user_id = @Id;
                    """;

                return await connection.QuerySingleOrDefaultAsync<User>(sql, new
                {
                    user.Id,
                    user.FirstName,
                    MiddleName = string.IsNullOrWhiteSpace(user.MiddleName) ? null : user.MiddleName,
                    user.LastName,
                    user.Email
                }) ?? throw new InvalidOperationException("Account not found.");
            }
            catch (MySqlException exception) when (exception.Number == 1062)
            {
                throw new InvalidOperationException("This email is already registered.", exception);
            }
            catch (MySqlException exception)
            {
                throw new InvalidOperationException("Unable to update your information. Please check your database connection and try again.", exception);
            }
        }
    }
}
