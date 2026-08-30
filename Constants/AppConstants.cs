namespace BlackHawk.Constants
{
    public static class AppConstants
    {
        public const string AppName = "BlackHawk";
        public const string AppVersion = "1.0.0";
        public const string AppBuildNumber = "001";
        public const string CompanyName = "BlackHawk OSINT";
        public const string DefaultLanguage = "tr";
        
        // API Timeouts
        public const int ApiTimeoutSeconds = 30;
        public const int LongApiTimeoutSeconds = 60;
        
        // Database
        public const string DatabaseFileName = "blackhawk.db3";
        public const int DatabaseVersion = 1;
        
        // Cache
        public const int CacheValidityHours = 24;
        public const int MaxCacheItems = 1000;
        
        // Search
        public const int MaxSearchResults = 100;
        public const int DefaultSearchPageSize = 20;
        
        // Notifications
        public const int DailyNotificationsCount = 4;
        
        // Security
        public const int PasswordMinLength = 8;
        public const int SessionTimeoutMinutes = 30;
    }

    public static class ApiEndpoints
    {
        public const string NewsApiBaseUrl = "https://newsapi.org/v2";
        public const string RedditBaseUrl = "https://www.reddit.com";
        public const string NewsApiEndpoint = "/everything";
    }

    public static class UIConstants
    {
        public const int DefaultCornerRadius = 10;
        public const int DefaultPadding = 20;
        public const int DefaultMargin = 15;
        public const double DefaultOpacity = 0.8;
    }
}
