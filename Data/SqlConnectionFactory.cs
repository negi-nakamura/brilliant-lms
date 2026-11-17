using brilliant_lms.Utilities;
using MySql.Data.MySqlClient;

namespace brilliant_lms.Data
{
    public class SqlConnectionFactory
    {
        public static SqlConnectionFactory Instance { get; } = new();

        private SqlConnectionFactory() { }

        public MySqlConnection CreateConnection()
        {
            return new(AppSettings.GetConnectionString());
        }
    }
}
