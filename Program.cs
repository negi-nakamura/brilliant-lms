using brilliant_lms.Data;
using brilliant_lms.Theme;

namespace brilliant_lms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            DatabaseInitializer.Initialize();
            ThemeManager.Initialize();
            Application.Initialize();
        }
    }
}