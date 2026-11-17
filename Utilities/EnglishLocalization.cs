namespace brilliant_lms.Utilities
{
    public class EnglishLocalization : AntdUI.ILocalization
    {
        public string? GetLocalizedString(string key)
        {
            switch (key)
            {
                case "ToDay":
                    return "Today";
                case "Now":
                    return "Now";
                case "OK":
                    return "OK";
                default:
                    return null;
            }
        }
    }
}