using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackHawk.Helpers
{
    public static class DangerKeywordHelper
    {
        private static List<string> _dangerousKeywords = new List<string>
        {
            "terör", "silah", "bomba", "saldırı", "ölüm", "cinayet",
            "terror", "weapon", "bomb", "attack", "death", "murder",
            "إرهاب", "سلاح", "قنبلة", "هجوم", "موت", "القتل"
        };

        public static bool ContainsDangerousKeyword(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            var lowerText = text.ToLower();
            return _dangerousKeywords.Any(kw => lowerText.Contains(kw));
        }

        public static List<string> GetMatchingKeywords(string text)
        {
            if (string.IsNullOrEmpty(text)) return new List<string>();
            var lowerText = text.ToLower();
            return _dangerousKeywords.Where(kw => lowerText.Contains(kw)).ToList();
        }

        public static int CalculateDangerLevel(string text)
        {
            var keywords = GetMatchingKeywords(text);
            return keywords.Count switch
            {
                0 => 0,
                1 => 1,
                2 => 2,
                3 => 3,
                _ => 4
            };
        }
    }
}
