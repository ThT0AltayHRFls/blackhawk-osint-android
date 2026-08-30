using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlackHawk.Models.Entities;

namespace BlackHawk.Services.Database
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _connection;
        private const string DatabaseFileName = "blackhawk.db3";

        public async Task InitializeAsync()
        {
            if (_connection != null) return;

            var dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                DatabaseFileName);

            _connection = new SQLiteAsyncConnection(dbPath);

            await _connection.CreateTableAsync<SearchResult>();
            await _connection.CreateTableAsync<SearchHistory>();
            await _connection.CreateTableAsync<SavedReport>();
            await _connection.CreateTableAsync<UserSettings>();
            await _connection.CreateTableAsync<CacheData>();
            await _connection.CreateTableAsync<Notification>();
            await _connection.CreateTableAsync<UserPreference>();
            await _connection.CreateTableAsync<SearchFilter>();
            await _connection.CreateTableAsync<AnalyticsEvent>();
        }

        // ========== SEARCH RESULTS ==========
        public async Task<bool> AddSearchResultAsync(SearchResult result)
        {
            try
            {
                await _connection.InsertAsync(result);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Database Error: {ex.Message}");
                return false;
            }
        }

        public async Task<List<SearchResult>> GetSearchResultsByQueryAsync(string query)
        {
            try
            {
                return await _connection.Table<SearchResult>()
                    .Where(r => r.Title.Contains(query) || r.Description.Contains(query))
                    .OrderByDescending(r => r.PublishDate)
                    .ToListAsync();
            }
            catch { return new List<SearchResult>(); }
        }

        public async Task<List<SearchResult>> GetDangerousContentAsync()
        {
            try
            {
                return await _connection.Table<SearchResult>()
                    .Where(r => r.HasDangerousContent)
                    .OrderByDescending(r => r.DangerLevel)
                    .ToListAsync();
            }
            catch { return new List<SearchResult>(); }
        }

        public async Task<bool> DeleteSearchResultAsync(int id)
        {
            try
            {
                await _connection.DeleteAsync<SearchResult>(id);
                return true;
            }
            catch { return false; }
        }

        // ========== SEARCH HISTORY ==========
        public async Task<bool> AddSearchHistoryAsync(SearchHistory history)
        {
            try
            {
                await _connection.InsertAsync(history);
                return true;
            }
            catch { return false; }
        }

        public async Task<List<SearchHistory>> GetSearchHistoryAsync(int limit = 50)
        {
            try
            {
                return await _connection.Table<SearchHistory>()
                    .OrderByDescending(x => x.SearchDate)
                    .Take(limit)
                    .ToListAsync();
            }
            catch { return new List<SearchHistory>(); }
        }

        public async Task<bool> ClearSearchHistoryAsync()
        {
            try
            {
                await _connection.DeleteAllAsync<SearchHistory>();
                return true;
            }
            catch { return false; }
        }

        // ========== SAVED REPORTS ==========
        public async Task<bool> SaveReportAsync(SavedReport report)
        {
            try
            {
                report.SavedDate = DateTime.Now;
                await _connection.InsertAsync(report);
                return true;
            }
            catch { return false; }
        }

        public async Task<List<SavedReport>> GetSavedReportsAsync()
        {
            try
            {
                return await _connection.Table<SavedReport>()
                    .OrderByDescending(x => x.SavedDate)
                    .ToListAsync();
            }
            catch { return new List<SavedReport>(); }
        }

        public async Task<SavedReport> GetReportByIdAsync(int id)
        {
            try
            {
                return await _connection.GetAsync<SavedReport>(id);
            }
            catch { return null; }
        }

        public async Task<bool> DeleteReportAsync(int id)
        {
            try
            {
                await _connection.DeleteAsync<SavedReport>(id);
                return true;
            }
            catch { return false; }
        }

        // ========== USER SETTINGS ==========
        public async Task<UserSettings> GetSettingsAsync()
        {
            try
            {
                var settings = await _connection.Table<UserSettings>().FirstOrDefaultAsync();
                if (settings == null)
                {
                    settings = new UserSettings();
                    await _connection.InsertAsync(settings);
                }
                return settings;
            }
            catch { return new UserSettings(); }
        }

        public async Task<bool> UpdateSettingsAsync(UserSettings settings)
        {
            try
            {
                await _connection.UpdateAsync(settings);
                return true;
            }
            catch { return false; }
        }

        // ========== CACHE ==========
        public async Task<bool> SaveCacheAsync(CacheData cache)
        {
            try
            {
                cache.CachedDate = DateTime.Now;
                cache.ExpiryDate = DateTime.Now.AddHours(24);
                var existing = await _connection.Table<CacheData>()
                    .Where(x => x.Query == cache.Query)
                    .FirstOrDefaultAsync();

                if (existing != null)
                {
                    await _connection.DeleteAsync(existing);
                }

                await _connection.InsertAsync(cache);
                return true;
            }
            catch { return false; }
        }

        public async Task<CacheData> GetCacheAsync(string query)
        {
            try
            {
                var cache = await _connection.Table<CacheData>()
                    .Where(x => x.Query == query)
                    .FirstOrDefaultAsync();

                if (cache != null && cache.ExpiryDate > DateTime.Now)
                {
                    cache.AccessCount++;
                    await _connection.UpdateAsync(cache);
                    return cache;
                }

                return null;
            }
            catch { return null; }
        }

        public async Task<bool> ClearOldCacheAsync()
        {
            try
            {
                var oldCache = await _connection.Table<CacheData>()
                    .Where(x => x.ExpiryDate < DateTime.Now)
                    .ToListAsync();

                foreach (var item in oldCache)
                {
                    await _connection.DeleteAsync(item);
                }

                return true;
            }
            catch { return false; }
        }

        // ========== NOTIFICATIONS ==========
        public async Task<bool> AddNotificationAsync(Notification notification)
        {
            try
            {
                await _connection.InsertAsync(notification);
                return true;
            }
            catch { return false; }
        }

        public async Task<List<Notification>> GetNotificationsAsync()
        {
            try
            {
                return await _connection.Table<Notification>()
                    .OrderByDescending(x => x.CreatedDate)
                    .ToListAsync();
            }
            catch { return new List<Notification>(); }
        }

        public async Task<int> GetUnreadNotificationCountAsync()
        {
            try
            {
                return await _connection.Table<Notification>()
                    .Where(x => !x.IsRead)
                    .CountAsync();
            }
            catch { return 0; }
        }

        public async Task<bool> MarkNotificationAsReadAsync(int id)
        {
            try
            {
                var notification = await _connection.GetAsync<Notification>(id);
                if (notification != null)
                {
                    notification.IsRead = true;
                    await _connection.UpdateAsync(notification);
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

        // ========== ANALYTICS ==========
        public async Task<bool> LogAnalyticsEventAsync(AnalyticsEvent analyticsEvent)
        {
            try
            {
                await _connection.InsertAsync(analyticsEvent);
                return true;
            }
            catch { return false; }
        }

        public async Task<long> GetDatabaseSizeAsync()
        {
            try
            {
                var dbPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    DatabaseFileName);
                
                if (File.Exists(dbPath))
                {
                    return new FileInfo(dbPath).Length;
                }
                return 0;
            }
            catch { return 0; }
        }

        public async Task<bool> ClearDatabaseAsync()
        {
            try
            {
                await _connection.DeleteAllAsync<SearchResult>();
                await _connection.DeleteAllAsync<SearchHistory>();
                await _connection.DeleteAllAsync<CacheData>();
                await _connection.DeleteAllAsync<Notification>();
                return true;
            }
            catch { return false; }
        }
    }
}
