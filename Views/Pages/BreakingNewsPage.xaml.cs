using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlackHawk.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BreakingNewsPage : ContentPage
    {
        public BreakingNewsPage()
        {
            InitializeComponent();
            BuildBreakingNewsUI();
        }

        private void BuildBreakingNewsUI()
        {
            var mainStack = new StackLayout
            {
                Padding = 20,
                Spacing = 15,
                BackgroundColor = Color.FromHex("#0A0E27")
            };

            // Breaking News Banner
            var breakingBanner = new Frame
            {
                BorderColor = Color.FromHex("#F56565"),
                CornerRadius = 10,
                Padding = 15,
                BackgroundColor = Color.FromHex("#2D1010"),
                Content = new StackLayout
                {
                    Spacing = 8,
                    Children =
                    {
                        new Label { Text = "🔴 SON DAKİKA", FontSize = 12, FontAttributes = FontAttributes.Bold, TextColor = Color.FromHex("#F56565") },
                        new Label { Text = "Türkiye'de büyük gelişme: Yeni teknoloji merkezi açıldı", FontSize = 14, FontAttributes = FontAttributes.Bold, TextColor = Color.White, LineBreakMode = LineBreakMode.WordWrap },
                        new Label { Text = "Şu anda: CANLI YAYIN", FontSize = 11, TextColor = Color.FromHex("#F56565") }
                    }
                }
            };

            // News Items
            var newsStack = new StackLayout { Spacing = 10 };

            var newsList = new[]
            {
                new { Time = "2 dakika önce", Title = "Borsada Rekor Kırıldı", Category = "Ekonomi", Hot = true },
                new { Time = "10 dakika önce", Title = "Milli Sporcu Altın Medal Kazandı", Category = "Spor", Hot = true },
                new { Time = "25 dakika önce", Title = "Hava Kirliliği Uyarısı", Category = "Çevre", Hot = false },
                new { Time = "45 dakika önce", Title = "Yeni Kanun Tasarısı Sunuldu", Category = "Politika", Hot = false }
            };

            foreach (var news in newsList)
            {
                var newsCard = new Frame
                {
                    BorderColor = news.Hot ? Color.FromHex("#00D9FF") : Color.FromHex("#2D3748"),
                    CornerRadius = 10,
                    Padding = 15,
                    BackgroundColor = Color.FromHex("#1A202C"),
                    Content = new StackLayout
                    {
                        Spacing = 8,
                        Children =
                        {
                            new Grid
                            {
                                ColumnDefinitions = new ColumnDefinitionCollection
                                {
                                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                                    new ColumnDefinition { Width = GridLength.Auto }
                                },
                                Children =
                                {
                                    new Label { Text = news.Title, FontSize = 13, FontAttributes = FontAttributes.Bold, TextColor = Color.White, LineBreakMode = LineBreakMode.WordWrap },
                                    news.Hot ? new Label { Text = "🔥 HOT", FontSize = 10, FontAttributes = FontAttributes.Bold, TextColor = Color.FromHex("#ED8936") } : null
                                }
                            },
                            new Grid
                            {
                                ColumnDefinitions = new ColumnDefinitionCollection
                                {
                                    new ColumnDefinition { Width = GridLength.Auto },
                                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                                },
                                Children =
                                {
                                    new Label { Text = $"#{news.Category}", FontSize = 10, TextColor = Color.FromHex("#00D9FF") },
                                    new Label { Text = news.Time, FontSize = 9, TextColor = Color.FromHex("#718096"), HorizontalTextAlignment = TextAlignment.End }
                                }
                            }
                        }
                    }
                };

                newsStack.Children.Add(newsCard);
            }

            mainStack.Children.Add(breakingBanner);
            mainStack.Children.Add(new Label { Text = "Son Dakika Haberleri", FontSize = 14, FontAttributes = FontAttributes.Bold, TextColor = Color.White, Margin = new Thickness(0, 10, 0, 0) });
            mainStack.Children.Add(newsStack);

            Content = new ScrollView { Content = mainStack };
        }
    }
}
