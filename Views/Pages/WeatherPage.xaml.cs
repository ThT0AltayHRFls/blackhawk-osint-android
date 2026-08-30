using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlackHawk.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            BuildWeatherUI();
        }

        private void BuildWeatherUI()
        {
            var mainStack = new StackLayout
            {
                Padding = 20,
                Spacing = 15,
                BackgroundColor = Color.FromHex("#0A0E27")
            };

            // Header
            var header = new Frame
            {
                BorderColor = Color.FromHex("#00D9FF"),
                CornerRadius = 15,
                Padding = 20,
                HasShadow = true,
                BackgroundColor = Color.FromHex("#12152E"),
                Content = new StackLayout
                {
                    Spacing = 10,
                    Children =
                    {
                        new Label { Text = "🌍 Hava Durumu", FontSize = 22, FontAttributes = FontAttributes.Bold, TextColor = Color.FromHex("#00D9FF") },
                        new Label { Text = "Konumunuza Özel Hava Tahmini", FontSize = 12, TextColor = Color.FromHex("#A0AEC0") }
                    }
                }
            };

            // Current Weather Card
            var currentWeatherCard = new Frame
            {
                BorderColor = Color.FromHex("#2D3748"),
                CornerRadius = 10,
                Padding = 20,
                BackgroundColor = Color.FromHex("#1A202C"),
                Content = new Grid
                {
                    ColumnDefinitions = new ColumnDefinitionCollection
                    {
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star),
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)
                    },
                    Children =
                    {
                        new StackLayout
                        {
                            Spacing = 5,
                            Children =
                            {
                                new Label { Text = "☀️ Bugün", FontSize = 14, FontAttributes = FontAttributes.Bold, TextColor = Color.White },
                                new Label { Text = "28°C", FontSize = 32, FontAttributes = FontAttributes.Bold, TextColor = Color.FromHex("#00D9FF") },
                                new Label { Text = "Açık gökyüzü", FontSize = 12, TextColor = Color.FromHex("#A0AEC0") },
                                new Label { Text = "Rüzgar: 12 km/h", FontSize = 10, TextColor = Color.FromHex("#718096") }
                            }
                        },
                        new StackLayout
                        {
                            Spacing = 5,
                            Children =
                            {
                                new Label { Text = "💧 Nem", FontSize = 12, TextColor = Color.FromHex("#718096") },
                                new Label { Text = "65%", FontSize = 20, FontAttributes = FontAttributes.Bold, TextColor = Color.White },
                                new Label { Text = "", FontSize = 5 },
                                new Label { Text = "🌡️ Hava Basıncı", FontSize = 12, TextColor = Color.FromHex("#718096") },
                                new Label { Text = "1013 mb", FontSize = 14, FontAttributes = FontAttributes.Bold, TextColor = Color.White }
                            }
                        }
                    }
                }
            };

            Grid.SetColumn(currentWeatherCard.Content as Grid, 0);

            // 5 Day Forecast
            var forecastLabel = new Label { Text = "📅 5 Günlük Tahmin", FontSize = 14, FontAttributes = FontAttributes.Bold, TextColor = Color.White };

            var forecastStack = new StackLayout { Spacing = 10 };
            var days = new[] { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma" };
            var temps = new[] { "26°C", "27°C", "25°C", "28°C", "26°C" };
            var icons = new[] { "⛅", "☀️", "🌧️", "☀️", "⛅" };

            for (int i = 0; i < days.Length; i++)
            {
                var dayCard = new Frame
                {
                    BorderColor = Color.FromHex("#2D3748"),
                    CornerRadius = 8,
                    Padding = 12,
                    BackgroundColor = Color.FromHex("#1A202C"),
                    Content = new Grid
                    {
                        ColumnDefinitions = new ColumnDefinitionCollection
                        {
                            new ColumnDefinition { Width = new GridLength(60, GridUnitType.Absolute),
                            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star),
                            new ColumnDefinition { Width = new GridLength(60, GridUnitType.Absolute)
                        },
                        Children =
                        {
                            new Label { Text = icons[i], FontSize = 24, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center },
                            new Label { Text = days[i], FontSize = 12, TextColor = Color.White, VerticalTextAlignment = TextAlignment.Center, Margin = new Thickness(10, 0, 0, 0) },
                            new Label { Text = temps[i], FontSize = 14, FontAttributes = FontAttributes.Bold, TextColor = Color.FromHex("#00D9FF"), HorizontalTextAlignment = TextAlignment.End, VerticalTextAlignment = TextAlignment.Center }
                        }
                    }
                };

                Grid.SetColumn(dayCard.Content as Grid, 0);
                forecastStack.Children.Add(dayCard);
            }

            mainStack.Children.Add(header);
            mainStack.Children.Add(currentWeatherCard);
            mainStack.Children.Add(forecastLabel);
            mainStack.Children.Add(forecastStack);

            Content = new ScrollView { Content = mainStack };
        }
    }
}
