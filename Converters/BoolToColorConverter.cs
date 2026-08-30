using Xamarin.Forms;

namespace BlackHawk.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is bool b)) return Color.Gray;
            return b ? Color.FromHex("#48BB78") : Color.FromHex("#F56565");
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((Color)value).Equals(Color.FromHex("#48BB78"));
        }
    }
}
