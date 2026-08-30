using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlackHawk.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecommendationsPage : ContentPage
    {
        public RecommendationsPage()
        {
            InitializeComponent();
            BuildRecommendationsUI();
        }

        private void BuildRecommendationsUI()
        {
            var mainStack = new StackLayout
            {
                Padding = 20,
                Spacing = 15,
                BackgroundColor = Color.FromHex("#0A0E27")
            };

            var header = new Frame
            {
                BorderColor = Color.FromHex("#00D9FF"),
                CornerRadius = 15,
                Padding = 20,
                BackgroundColor = Color.FromHex("#12152E"),
                Content = new StackLayout
                {
                    Spacing = 10,
                    Children =
                    {
                        new Label { Text = "💡 Önerilen Aramalar", FontSize = 22, FontAttributes = FontAttributes.Bold, TextColor = Color.FromHex("#00D9FF") },
                        new Label { Text = "Sizin için seçilen içerik", FontSize = 12, TextColor = Color.FromHex("#A0AEC0") }
                    }
                }
            };

            var recommendationsStack = new StackLayout { Spacing = 10 };

            var recommendations = new[]
            {
                "Yapay Zeka ve Teknoloji Trendleri",
                "Yeşil Enerji Projeleleri Türkiye",
                "Kripto Para Pazar Analizi",
                "Sağlık Teknolojileri Gelişmeleri",
                "Otomotiv Sektörü Haber",
                "Eğitim İnovasyonları"
            };

            foreach (var rec in recommendations)
            {
                var recCard = new Frame
                {
                    BorderColor = Color.FromHex("#2D3748"),
                    CornerRadius = 8,
                    Padding = 12,
                    BackgroundColor = Color.FromHex("#1A202C"),
                    Content = new Grid
                    {
                        ColumnDefinitions = new ColumnDefinitionCollection
                        {
                            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                            new ColumnDefinition { Width = GridLength.Auto }
                        },
                        Children =
                        {
                            new Label { Text = rec, FontSize = 12, TextColor = Color.White, VerticalTextAlignment = TextAlignment.Center },
                            new Button { Text = "➜", BackgroundColor = Color.FromHex("#00D9FF"), TextColor = Color.FromHex("#0A0E27"), CornerRadius = 5, Padding = 5 }
                        }
                    }
                };

                Grid.SetColumn(recCard.Content as Grid, 0);
                recommendationsStack.Children.Add(recCard);
            }

            mainStack.Children.Add(header);
            mainStack.Children.Add(recommendationsStack);

            Content = new ScrollView { Content = mainStack };
        }
    }
}
