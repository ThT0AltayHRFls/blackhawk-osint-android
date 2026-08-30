using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlackHawk.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
            BuildDashboardUI();
        }

        private void BuildDashboardUI()
        {
            var mainStack = new StackLayout
            {
                Padding = 20,
                Spacing = 10,
                BackgroundColor = Color.FromHex("#0A0E27")
            };

            // Top Bar with Quick Stats
            var quickStatsGrid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },
                ColumnSpacing = 10,
                Children =
                {
                    CreateStatCard("📊", "Araşt.", "1,247", Color.FromHex("#00D9FF")),
                    CreateStatCard("📰", "Haber", "342", Color.FromHex("#48BB78")),
                    CreateStatCard("⏰", "Son", "5 min", Color.FromHex("#ED8936"))
                }
            };

            mainStack.Children.Add(quickStatsGrid);

            // Featured Content
            var featuredLabel = new Label { Text = "✨ Öne Çıkan İçerik", FontSize = 14, FontAttributes = FontAttributes.Bold, TextColor = Color.White, Margin = new Thickness(0, 15, 0, 10) };
            mainStack.Children.Add(featuredLabel);

            var featuredCard = new Frame
            {
                BorderColor = Color.FromHex("#00D9FF"),
                CornerRadius = 10,
                Padding = 15,
                BackgroundColor = Color.FromHex("#12152E"),
                Content = new StackLayout
                {
                    Spacing = 8,
                    Children =
                    {
                        new Label { Text = "Türkiye Teknoloji Sektöründe Lider", FontSize = 13, FontAttributes = FontAttributes.Bold, TextColor = Color.White },
                        new Label { Text = "Son araştırmalar Türkiye'nin teknoloji alanında önemli gelişmeler yaptığını gösteriyor.", FontSize = 11, TextColor = Color.FromHex("#A0AEC0"), LineBreakMode = LineBreakMode.WordWrap },
                        new Label { Text = "1,247 kaynak • 45 ülke • Güncelleniyor...", FontSize = 9, TextColor = Color.FromHex("#718096") }
                    }
                }
            };
            mainStack.Children.Add(featuredCard);

            // Quick Links
            var linksLabel = new Label { Text = "⚡ Hızlı Erişim", FontSize = 14, FontAttributes = FontAttributes.Bold, TextColor = Color.White, Margin = new Thickness(0, 15, 0, 10) };
            mainStack.Children.Add(linksLabel);

            var linksGrid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },
                RowSpacing = 10,
                ColumnSpacing = 10,
                Children =
                {
                    CreateLinkButton("🌍 Harita", "Coğrafi analiz"),
                    CreateLinkButton("📄 Raporlar", "Detaylı rapor"),
                    CreateLinkButton("🔔 Uyarılar", "Son dakika"),
                    CreateLinkButton("📊 Analytics", "İstatistikler")
                }
            };
            mainStack.Children.Add(linksGrid);

            Content = new ScrollView { Content = mainStack };
        }

        private Frame CreateStatCard(string icon, string title, string value, Color color)
        {
            return new Frame
            {
                BorderColor = color,
                CornerRadius = 8,
                Padding = 12,
                BackgroundColor = Color.FromHex("#1A202C"),
                Content = new StackLayout
                {
                    Spacing = 5,
                    HorizontalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label { Text = icon, FontSize = 20, HorizontalTextAlignment = TextAlignment.Center },
                        new Label { Text = title, FontSize = 10, TextColor = Color.FromHex("#718096"), HorizontalTextAlignment = TextAlignment.Center },
                        new Label { Text = value, FontSize = 14, FontAttributes = FontAttributes.Bold, TextColor = color, HorizontalTextAlignment = TextAlignment.Center }
                    }
                }
            };
        }

        private Frame CreateLinkButton(string title, string subtitle)
        {
            return new Frame
            {
                BorderColor = Color.FromHex("#2D3748"),
                CornerRadius = 8,
                Padding = 12,
                BackgroundColor = Color.FromHex("#12152E"),
                Content = new StackLayout
                {
                    Spacing = 3,
                    Children =
                    {
                        new Label { Text = title, FontSize = 12, FontAttributes = FontAttributes.Bold, TextColor = Color.FromHex("#00D9FF") },
                        new Label { Text = subtitle, FontSize = 9, TextColor = Color.FromHex("#718096") }
                    }
                }
            };
        }
    }
}
