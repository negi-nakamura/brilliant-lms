using brilliant_lms.Utilities;

namespace brilliant_lms.Theme
{
    public static class ThemeManager
    {
        public static event EventHandler? ThemeChanged;

        public static void Initialize()
        {
            AntdUI.Config.Theme().Dark("#000", "#fff").Light("#fff", "#000").FormBorderColor();
            AntdUI.Config.IsLight = WindowsTheme.IsLightMode();
            AntdUI.Localization.Provider = new EnglishLocalization();
            AntdUI.Localization.SetLanguage("en-US");
        }

        public static void Toggle()
        {
            AntdUI.Config.IsLight = !AntdUI.Config.IsLight;
            ThemeChanged?.Invoke(null, EventArgs.Empty);
        }

        public static Color DividerColor
        {
            get
            {
                if (AntdUI.Config.IsLight)
                    return Color.FromArgb(240, 240, 240);
                else
                    return Color.FromArgb(48, 48, 48);
            }
        }
    }
}
