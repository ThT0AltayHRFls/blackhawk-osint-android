using System;

namespace BlackHawk.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidUrl(this string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }

        public static string Truncate(this string text, int length)
        {
            if (text == null) return null;
            return text.Length > length ? text.Substring(0, length) + "..." : text;
        }

        public static bool ContainsIgnoreCase(this string text, string value)
        {
            return text?.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static string RemoveSpecialCharacters(this string text)
        {
            return System.Text.RegularExpressions.Regex.Replace(text, "[^a-zA-Z0-9 ]", "");
        }
    }
}
