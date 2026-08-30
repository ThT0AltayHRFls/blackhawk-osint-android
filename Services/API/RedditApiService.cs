using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackHawk.Models.Entities;
using BlackHawk.Models.Responses;
using BlackHawk.Helpers;

namespace BlackHawk.Services.API
{
    public class RedditApiService
    {
        private const string BaseUrl = "https://www.reddit.com";
        private readonly ApiService _apiService;

        public RedditApiService()
        {
            _apiService = new ApiService();
            _apiService.SetUserAgent("BlackHawkOSINT/1.0 (+http://blackhawk.local)");
        }

        public async Task<List<SearchResult>> SearchAsync(string query)
        {
            try
            {
                var url = $"{BaseUrl}/r/worldnews/search.json?q={Uri.EscapeDataString(query)}&type=sr,link&sort=new&t=month&limit=25";

                var response = await _apiService.GetAsync<RedditResponse>(url);
                if (response?.Data?.Children == null)
                    return new List<SearchResult>();

                var results = new List<SearchResult>();

                foreach (var child in response.Data.Children)
                {
                    if (child.Data == null) continue;

                    var text = $"{child.Data.Title} {child.Data.Selftext}";
                    var result = new SearchResult
                    {
                        Title = child.Data.Title,
                        Description = child.Data.Selftext?.Substring(0, Math.Min(500, child.Data.Selftext.Length)) ?? "",
                        Url = $"https://reddit.com{child.Data.Permalink}",
                        Source = $"r/{child.Data.Subreddit}",
                        PublishDate = UnixTimeStampToDateTime(child.Data.CreatedUtc),
                        Country = ExtractCountry(text),
                        HasDangerousContent = DangerKeywordHelper.ContainsDangerousKeyword(text),
                        DangerLevel = DangerKeywordHelper.CalculateDangerLevel(text),
                        Platform = "Reddit"
                    };

                    results.Add(result);
                }

                return results;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Reddit Search Error: {ex.Message}");
                return new List<SearchResult>();
            }
        }

        private string ExtractCountry(string text)
        {
            return "Unknown";
        }

        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
