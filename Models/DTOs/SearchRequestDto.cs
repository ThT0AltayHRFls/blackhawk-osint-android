using System;
using System.Collections.Generic;

namespace BlackHawk.Models.DTOs
{
    public class SearchRequestDto
    {
        public string Query { get; set; }
        public List<string> Platforms { get; set; } = new List<string> { "news", "reddit", "web" };
        public List<string> Countries { get; set; } = new List<string>();
        public bool IncludeDangerousContent { get; set; } = true;
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Language { get; set; } = "en";
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
        public bool OfflineMode { get; set; } = false;
    }

    public class ReportGenerationDto
    {
        public string Title { get; set; }
        public string Query { get; set; }
        public List<Entities.SearchResult> Results { get; set; }
        public bool IncludeMaps { get; set; } = true;
        public bool IncludeScreenshots { get; set; } = true;
        public bool IncludeAnalytics { get; set; } = true;
        public string Language { get; set; } = "tr";
    }

    public class LocationFilterDto
    {
        public string CountryCode { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float RadiusKm { get; set; }
    }
}
