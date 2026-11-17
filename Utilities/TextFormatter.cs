using brilliant_lms.Models.Entities;
using System.Globalization;

namespace brilliant_lms.Utilities
{
    public static class TextFormatter
    {
        public static string GetFullName(User user)
        {
            return GetFullName(user.FirstName, user.MiddleName, user.LastName);
        }

        public static string GetFullName(string firstName, string? middleName, string lastName)
        {
            return string.Join(" ", new[]
            {
                firstName,
                middleName,
                lastName
            }.Where(x => !string.IsNullOrWhiteSpace(x))
             .Select(x => x!.Trim()));
        }

        public static string GetInitials(User user)
        {
            return GetInitial(user.FirstName) + GetInitial(user.LastName);
        }

        public static string GetInitials(string name)
        {
            return GetInitial(name);
        }

        private static string GetInitial(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            return StringInfo.GetNextTextElement(name.Trim()).ToUpperInvariant();
        }
    }
}
