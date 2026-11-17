using System.Text;

namespace brilliant_lms.Utilities
{
    public static class CsvExporter
    {
        public static void Write(string path, string[] headers, List<string[]> rows)
        {
            using StreamWriter writer = new StreamWriter(path, false, new UTF8Encoding(true));
            writer.WriteLine(string.Join(",", headers.Select(Escape)));
            foreach (string[] row in rows)
                writer.WriteLine(string.Join(",", row.Select(Escape)));
        }

        private static string Escape(string value)
        {
            string text = value.TrimStart();
            if (text.StartsWith('=') || text.StartsWith('+') || text.StartsWith('-') || text.StartsWith('@') ||
                value.StartsWith('\t') || value.StartsWith('\r') || value.StartsWith('\n'))
                value = "'" + value;
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }
    }
}
