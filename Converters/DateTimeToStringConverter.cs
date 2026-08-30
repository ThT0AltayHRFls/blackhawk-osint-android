using System;
using Xamarin.Forms;

namespace BlackHawk.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is DateTime dt)) return "";
            return dt.ToString("dd/MM/yyyy HH:mm");
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return DateTime.Now;
        }
    }
}
