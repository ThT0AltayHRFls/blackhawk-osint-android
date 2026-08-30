using System;

namespace BlackHawk.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToRelativeString(this DateTime dateTime)
        {
            var timeSpan = DateTime.Now - dateTime;

            if (timeSpan.TotalSeconds < 60)
                return "just now";
            if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes} minutes ago";
            if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours} hours ago";
            if (timeSpan.TotalDays < 7)
                return $"{(int)timeSpan.TotalDays} days ago";

            return dateTime.ToString("dd/MM/yyyy");
        }

        public static bool IsToday(this DateTime dateTime)
        {
            return dateTime.Date == DateTime.Today;
        }

        public static bool IsYesterday(this DateTime dateTime)
        {
            return dateTime.Date == DateTime.Today.AddDays(-1);
        }
    }
}
