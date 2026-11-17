using Microsoft.Win32;

namespace brilliant_lms.Utilities
{
    public static class WindowsTheme
    {
        public static bool IsLightMode()
        {
            using RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");
            return key?.GetValue("AppsUseLightTheme") is not int value || value != 0;
        }
    }
}
