using Xamarin.Essentials;

namespace BlackHawk.Settings
{
    public static class AppSettings
    {
        private const string LanguageKey = "app_language";
        private const string DarkModeKey = "dark_mode";
        private const string NotificationsKey = "notifications_enabled";

        public static string Language
        {
            get => Preferences.Get(LanguageKey, "tr");
            set => Preferences.Set(LanguageKey, value);
        }

        public static bool DarkMode
        {
            get => Preferences.Get(DarkModeKey, true);
            set => Preferences.Set(DarkModeKey, value);
        }

        public static bool NotificationsEnabled
        {
            get => Preferences.Get(NotificationsKey, true);
            set => Preferences.Set(NotificationsKey, value);
        }
    }
}
