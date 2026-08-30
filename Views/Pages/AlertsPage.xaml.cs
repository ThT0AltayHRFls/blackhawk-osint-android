using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlackHawk.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlertsPage : ContentPage
    {
        public AlertsPage()
        {
            InitializeComponent();
            BuildAlertsUI();
        }

        private void BuildAlertsUI()
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
                        new Label { Text = "🚨 Son Dakika Uyarıları", FontSize = 22, FontAttributes = FontAttributes.Bold, TextColor = Color.FromHex("#00D9FF") },
                        new Label { Text = "Gerçek zamanlı bildirimler", FontSize = 12, TextColor = Color.FromHex("#A0AEC0") }
                    }
                }
            };

            // Alert Cards
            var alertsStack = new StackLayout { Spacing = 10 };

            var alerts = new[]
            {
                new { Icon = "🔴", Title = "Acil: Trafik Durması", Message = "Türkiye - İstanbul'da büyük trafik durması", Time = "5 dakika önce", Priority = "Yüksek" },
                new { Icon = "🟠", Title = "Uyarı: Hava Kirliliği", Message = "Ankara'da hava kalitesi kötüleşti", Time = "15 dakika önce", Priority = "Orta" },
                new { Icon = "🟡", Title = "Bilgi: Spor Haberi", Message = "Besiktas 2-1 Galatasaray'ı yendi", Time = "1 saat önce", Priority = "Düşük" }
            };

            foreach (var alert in alerts)
            {
                var alertCard = new Frame
                {
                    BorderColor = alert.Priority switch
                    {
                        "Yüksek" => Color.FromHex("#F56565"),
                        "Orta" => Color.FromHex("#ED8936"),
                        _ => Color.FromHex("#48BB78")
                    },
                    BorderWidth = 1,
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
                                    new ColumnDefinition { Width = GridLength.Auto },
                                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                                },
                                Children =
                                {
                                    new Label { Text = alert.Icon, FontSize = 24 },
                                    new StackLayout
                                    {
                                        Spacing = 2,
                                        Children =
                                        {
                                            new Label { Text = alert.Title, FontSize = 13, FontAttributes = FontAttributes.Bold, TextColor = Color.White },
                                            new Label { Text = alert.Time, FontSize = 10, TextColor = Color.FromHex("#718096") }
                                        }
                                    }
                                }
                            },
                            new Label { Text = alert.Message, FontSize = 12, TextColor = Color.FromHex("#A0AEC0"), LineBreakMode = LineBreakMode.WordWrap },
                            new BoxView { HeightRequest = 1, Color = Color.FromHex("#2D3748") },
                            new Label { Text = $"Öncelik: {alert.Priority}", FontSize = 10, TextColor = Color.FromHex("#718096") }
                        }
                    }
                };

                alertsStack.Children.Add(alertCard);
            }

            mainStack.Children.Add(header);
            mainStack.Children.Add(new Label { Text = "Bugünün Uyarıları", FontSize = 14, FontAttributes = FontAttributes.Bold, TextColor = Color.White });
            mainStack.Children.Add(alertsStack);

            Content = new ScrollView { Content = mainStack };
        }
    }
}
