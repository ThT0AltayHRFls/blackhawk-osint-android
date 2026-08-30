using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackHawk.Models.DTOs;
using BlackHawk.Models.Entities;
using BlackHawk.Models.Responses;
using BlackHawk.Helpers;

namespace BlackHawk.Services.API
{
    public class NewsApiService
    {
        private const string BaseUrl = "https://newsapi.org/v2";
        private const string ApiKeyPlaceholder = "YOUR_NEWS_API_KEY";
        private readonly ApiService _apiService;

        public NewsApiService()
        {
            _apiService = new ApiService();
        }

        public async Task<List<SearchResult>> SearchAsync(string query, string language = "en")
        {
            try
            {
                var url = $"{BaseUrl}/everything?q={Uri.EscapeDataString(query)}&language={language}&sortBy=publishedAt&pageSize=20&apiKey={ApiKeyPlaceholder}";

                var response = await _apiService.GetAsync<NewsApiResponse>(url);
                if (response?.Articles == null)
                    return new List<SearchResult>();

                var results = new List<SearchResult>();

                foreach (var article in response.Articles)
                {
                    var text = $"{article.Title} {article.Description}";
                    var result = new SearchResult
                    {
                        Title = article.Title,
                        Description = article.Description,
                        Url = article.Url,
                        Source = article.Source?.Name ?? "Unknown",
                        PublishDate = article.PublishedAt,
                        ImageUrl = article.UrlToImage,
                        Country = ExtractCountry(text),
                        HasDangerousContent = DangerKeywordHelper.ContainsDangerousKeyword(text),
                        DangerLevel = DangerKeywordHelper.CalculateDangerLevel(text),
                        Platform = "NewsAPI",
                        Language = language
                    };

                    results.Add(result);
                }

                return results;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"News Search Error: {ex.Message}");
                return new List<SearchResult>();
            }
        }

        private string ExtractCountry(string text)
        {
            var countries = new Dictionary<string, string>
            {
                { "turkey", "Turkey" },
                { "türkiye", "Turkey" },
                { "usa", "USA" },
                { "china", "China" },
                { "russia", "Russia" },
                { "india", "India" },
                { "german", "Germany" },
                { "france", "France" },
                { "uk", "United Kingdom" },
                { "japan", "Japan" },
                { "korea", "South Korea" }
            };

            var lowerText = text.ToLower();
            foreach (var country in countries)
            {
                if (lowerText.Contains(country.Key))
                    return country.Value;
            }

            return "Unknown";
        }
    }
}
