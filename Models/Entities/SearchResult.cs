using SQLite;
using System;

namespace BlackHawk.Models.Entities
{
    [Table("search_results")]
    public class SearchResult
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Source { get; set; }
        public DateTime PublishDate { get; set; }
        public string ImageUrl { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public bool HasDangerousContent { get; set; }
        public int DangerLevel { get; set; } // 0-4
        public string Platform { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int Relevance { get; set; } // 0-100
        public string Language { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    [Table("search_history")]
    public class SearchHistory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string Query { get; set; }
        public DateTime SearchDate { get; set; }
        public int ResultCount { get; set; }
        public string CountriesFound { get; set; }
        public bool HasDangerousContent { get; set; }
        public int DangerLevel { get; set; }
        public string FiltersUsed { get; set; }
        public long ExecutionTimeMs { get; set; }
    }

    [Table("saved_reports")]
    public class SavedReport
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string ReportTitle { get; set; }
        public string Query { get; set; }
        public DateTime SavedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PdfPath { get; set; }
        public string Summary { get; set; }
        public int ResultCount { get; set; }
        public byte[] ThumbnailImage { get; set; }
        public string LanguageUsed { get; set; }
        public long FileSizeBytes { get; set; }
        public string Tags { get; set; }
        public bool IsStarred { get; set; }
    }

    [Table("user_settings")]
    public class UserSettings
    {
        [PrimaryKey]
        public int Id { get; set; } = 1;
        
        public string Language { get; set; } = "tr";
        public bool NotificationsEnabled { get; set; } = true;
        public bool DarkMode { get; set; } = true;
        public bool AutoRefresh { get; set; } = true;
        public DateTime LastRefresh { get; set; }
        public bool IncludeDangerousContent { get; set; } = true;
        public bool OfflineModeEnabled { get; set; } = false;
        public int CacheSizeMb { get; set; } = 500;
    }

    [Table("cache_data")]
    public class CacheData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string Query { get; set; }
        public string JsonData { get; set; }
        public DateTime CachedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Platform { get; set; }
        public int AccessCount { get; set; } = 0;
    }

    [Table("notifications")]
    public class Notification
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsRead { get; set; } = false;
        public string Type { get; set; } // news, alert, update
        public string Data { get; set; }
        public int Priority { get; set; }
    }

    [Table("user_preferences")]
    public class UserPreference
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    [Table("search_filters")]
    public class SearchFilter
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilterJson { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    [Table("analytics_events")]
    public class AnalyticsEvent
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string EventName { get; set; }
        public string EventData { get; set; }
        public DateTime EventDate { get; set; }
        public string DeviceId { get; set; }
        public string AppVersion { get; set; }
    }
}
