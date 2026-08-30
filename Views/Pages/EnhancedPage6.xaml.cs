using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlackHawk.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnhancedPage6 : ContentPage
    {
        public EnhancedPage6()
        {
            InitializeComponent();
            BuildUI();
        }

        private void BuildUI()
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
                Content = new Label { Text = "Sayfa 6", FontSize = 22, FontAttributes = FontAttributes.Bold, TextColor = Color.FromHex("#00D9FF") }
            };

            var contentCard = new Frame
            {
                BorderColor = Color.FromHex("#2D3748"),
                CornerRadius = 10,
                Padding = 15,
                BackgroundColor = Color.FromHex("#1A202C"),
                Content = new StackLayout
                {
                    Spacing = 10,
                    Children =
                    {
                        new Label { Text = "İçerik 6", FontSize = 16, FontAttributes = FontAttributes.Bold, TextColor = Color.White },
                        new Label { Text = "Bu sayfa geliştirilmiş kullanıcı arayüzü ile tasarlanmıştır.", FontSize = 12, TextColor = Color.FromHex("#A0AEC0"), LineBreakMode = LineBreakMode.WordWrap },
                        new Label { Text = "Son güncelleme: Şu anda", FontSize = 10, TextColor = Color.FromHex("#718096") }
                    }
                }
            };

            mainStack.Children.Add(header);
            mainStack.Children.Add(contentCard);

            Content = new ScrollView { Content = mainStack };
        }
    }
}
