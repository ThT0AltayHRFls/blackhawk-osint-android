using Xamarin.Forms;

namespace BlackHawk.Converters
{
    public class CountryToFlagConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is string country)) return "🌍";
            
            return country switch
            {
                "Turkey" => "🇹🇷",
                "USA" => "🇺🇸",
                "China" => "🇨🇳",
                "Russia" => "🇷🇺",
                "United Kingdom" => "🇬🇧",
                "France" => "🇫🇷",
                "Germany" => "🇩🇪",
                "India" => "🇮🇳",
                "Japan" => "🇯🇵",
                "Brazil" => "🇧🇷",
                _ => "🌍"
            };
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return "";
        }
    }
}
