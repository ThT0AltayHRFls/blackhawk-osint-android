using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlackHawk.Models.Entities;
using BlackHawk.Services.Database;

namespace BlackHawk.Services.Analytics
{
    public class AnalyticsService
    {
        private readonly DatabaseService _databaseService;

        public AnalyticsService(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task TrackEventAsync(string eventName, Dictionary<string, string> parameters = null)
        {
            try
            {
                var analyticsEvent = new AnalyticsEvent
                {
                    EventName = eventName,
                    EventDate = DateTime.Now,
                    DeviceId = Guid.NewGuid().ToString(),
                    AppVersion = "1.0.0",
                    EventData = Newtonsoft.Json.JsonConvert.SerializeObject(parameters)
                };

                await _databaseService.LogAnalyticsEventAsync(analyticsEvent);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Analytics error: {ex.Message}");
            }
        }

        public async Task TrackPageViewAsync(string pageName)
        {
            await TrackEventAsync("PageView", new Dictionary<string, string> { { "PageName", pageName } });
        }

        public async Task TrackSearchAsync(string query, int resultCount)
        {
            await TrackEventAsync("Search", new Dictionary<string, string>
            {
                { "Query", query },
                { "ResultCount", resultCount.ToString() }
            });
        }

        public async Task TrackExceptionAsync(Exception exception)
        {
            await TrackEventAsync("Exception", new Dictionary<string, string>
            {
                { "Message", exception.Message },
                { "StackTrace", exception.StackTrace }
            });
        }
    }
}
