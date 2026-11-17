using System.Text.Json;

namespace brilliant_lms.Utilities
{
    public static class AppSettings
    {
        public static string GetConnectionString()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "appsettings.json");

            using JsonDocument json = JsonDocument.Parse(File.ReadAllText(path));

            if (!json.RootElement.TryGetProperty("ConnectionStrings", out JsonElement connections)
                || connections.ValueKind != JsonValueKind.Object
                || !connections.TryGetProperty("DefaultConnection", out JsonElement connection)
                || connection.ValueKind != JsonValueKind.String
                || string.IsNullOrWhiteSpace(connection.GetString()))
            {
                throw new InvalidOperationException("DefaultConnection is missing or empty in appsettings.json.");
            }

            return connection.GetString()!;
        }
    }
}
