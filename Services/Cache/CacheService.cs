using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlackHawk.Services.Cache
{
    public class CacheService
    {
        private Dictionary<string, CacheItem> _memoryCache;
        private readonly object _lockObject = new object();

        public CacheService()
        {
            _memoryCache = new Dictionary<string, CacheItem>();
        }

        public async Task<T> GetAsync<T>(string key) where T : class
        {
            lock (_lockObject)
            {
                if (_memoryCache.TryGetValue(key, out var item))
                {
                    if (DateTime.Now < item.ExpiryTime)
                    {
                        item.AccessCount++;
                        return item.Value as T;
                    }

                    _memoryCache.Remove(key);
                }
            }

            return null;
        }

        public async Task SetAsync<T>(string key, T value, int expiryMinutes = 60) where T : class
        {
            lock (_lockObject)
            {
                _memoryCache[key] = new CacheItem
                {
                    Value = value,
                    ExpiryTime = DateTime.Now.AddMinutes(expiryMinutes),
                    CreatedTime = DateTime.Now
                };
            }
        }

        public async Task RemoveAsync(string key)
        {
            lock (_lockObject)
            {
                if (_memoryCache.ContainsKey(key))
                {
                    _memoryCache.Remove(key);
                }
            }
        }

        public async Task ClearAllAsync()
        {
            lock (_lockObject)
            {
                _memoryCache.Clear();
            }
        }

        public async Task CleanExpiredAsync()
        {
            lock (_lockObject)
            {
                var expiredKeys = _memoryCache
                    .Where(x => DateTime.Now >= x.Value.ExpiryTime)
                    .Select(x => x.Key)
                    .ToList();

                foreach (var key in expiredKeys)
                {
                    _memoryCache.Remove(key);
                }
            }
        }

        private class CacheItem
        {
            public object Value { get; set; }
            public DateTime ExpiryTime { get; set; }
            public DateTime CreatedTime { get; set; }
            public int AccessCount { get; set; }
        }
    }
}
