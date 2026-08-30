using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackHawk.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(T entity);
    }

    public interface ISearchRepository
    {
        Task<List<Models.SearchResult>> SearchAsync(string query, string filter);
        Task<List<Models.SearchHistory>> GetHistoryAsync();
        Task<bool> SaveSearchAsync(Models.SearchResult result);
    }

    public interface INetworkService
    {
        Task<bool> IsNetworkAvailableAsync();
        Task<T> GetAsync<T>(string url) where T : class;
        Task<T> PostAsync<T>(string url, object data) where T : class;
    }

    public interface INotificationService
    {
        Task SendNotificationAsync(string title, string message);
        Task SendLocalNotificationAsync(string title, string message, int delaySeconds);
        Task ScheduleDailyNotificationsAsync();
    }

    public interface ILocalizationService
    {
        string GetString(string key);
        void SetLanguage(string languageCode);
        string GetCurrentLanguage();
    }

    public interface IPdfService
    {
        Task<string> GeneratePdfAsync(Models.ReportConfig config);
        Task<bool> SavePdfAsync(string filePath, byte[] pdfData);
    }

    public interface IMapService
    {
        void InitializeMap();
        void UpdateMapMarkers(List<Models.LocationInfo> locations);
        void ZoomToLocation(float latitude, float longitude);
    }

    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key) where T : class;
        Task SetAsync<T>(string key, T value) where T : class;
        Task RemoveAsync(string key);
        Task ClearAllAsync();
    }

    public interface IAnalyticsService
    {
        void TrackEvent(string eventName, Dictionary<string, string> parameters = null);
        void TrackPageView(string pageName);
        void TrackException(Exception exception);
    }
}
