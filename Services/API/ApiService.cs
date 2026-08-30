using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlackHawk.Services.API
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const int TimeoutSeconds = 30;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(TimeoutSeconds);
        }

        public async Task<T> GetAsync<T>(string url) where T : class
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return null;

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"API Error: {ex.Message}");
                return null;
            }
        }

        public async Task<T> PostAsync<T>(string url, object data) where T : class
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);
                if (!response.IsSuccessStatusCode)
                    return null;

                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"API Error: {ex.Message}");
                return null;
            }
        }

        public void SetAuthorizationHeader(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", token);
        }

        public void SetUserAgent(string userAgent)
        {
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
        }
    }
}
