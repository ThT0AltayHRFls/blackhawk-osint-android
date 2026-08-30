using Newtonsoft.Json;
using System.Collections.Generic;

namespace BlackHawk.Models.Responses
{
    public class RedditResponse
    {
        [JsonProperty("data")]
        public RedditData Data { get; set; }
    }

    public class RedditData
    {
        [JsonProperty("children")]
        public List<RedditChild> Children { get; set; } = new List<RedditChild>();
    }

    public class RedditChild
    {
        [JsonProperty("data")]
        public RedditPost Data { get; set; }
    }

    public class RedditPost
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("selftext")]
        public string Selftext { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("permalink")]
        public string Permalink { get; set; }
        
        [JsonProperty("subreddit")]
        public string Subreddit { get; set; }
        
        [JsonProperty("created_utc")]
        public double CreatedUtc { get; set; }
        
        [JsonProperty("score")]
        public int Score { get; set; }
        
        [JsonProperty("num_comments")]
        public int NumComments { get; set; }
    }
}
