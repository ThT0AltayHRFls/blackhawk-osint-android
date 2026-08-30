using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace BlackHawk;

public sealed class StartupPage : ContentPage
{
    private readonly Label _statusLabel;

    public StartupPage()
    {
        Title = "BlackHawk OSINT";
        BackgroundColor = Color.FromArgb("#0A0E27");

        _statusLabel = new Label
        {
            TextColor = Color.FromArgb("#A0AEC0"),
            FontSize = 13,
            HorizontalOptions = LayoutOptions.Center
        };

        Content = new ScrollView
        {
            Content = new VerticalStackLayout
            {
                Padding = new Thickness(24, 32),
                Spacing = 18,
                Children =
                {
                    new Label
                    {
                        Text = "BLACKHAWK",
                        TextColor = Color.FromArgb("#00D9FF"),
                        FontSize = 30,
                        FontAttributes = FontAttributes.Bold
                    },
                    new Label
                    {
                        Text = "Açık kaynak istihbarat kontrol paneli",
                        TextColor = Colors.White,
                        FontSize = 17
                    },
                    new Label
                    {
                        Text = "Güvenli çevrimdışı başlangıç paneli hazır. Veri sağlayıcıları yapılandırıldığında kartlar canlı kaynaklarla beslenebilir.",
                        TextColor = Color.FromArgb("#A0AEC0"),
                        FontSize = 14
                    },
                    CreateCard("📊", "Araştırmalar", "Hazır", "#48BB78"),
                    CreateCard("🌍", "Küresel görünüm", "Çevrimdışı", "#A0AEC0"),
                    CreateCard("📰", "Haber akışı", "Yapılandırılmayı bekliyor", "#A0AEC0"),
                    CreateCard("🔐", "Yerel depolama", "Güvenli", "#48BB78"),
                    new Button
                    {
                        Text = "Arama modülünü yapılandır",
                        BackgroundColor = Color.FromArgb("#00D9FF"),
                        TextColor = Color.FromArgb("#071126"),
                        CornerRadius = 12,
                        Command = new Command(() =>
                            _statusLabel.Text = "Yapılandırma için config.json dosyasını doldurun.")
                    },
                    _statusLabel
                }
            }
        };
    }

    private static View CreateCard(string icon, string title, string status, string statusColor)
    {
        return new Frame
        {
            BackgroundColor = Color.FromArgb("#111A3A"),
            BorderColor = Color.FromArgb("#1E376B"),
            CornerRadius = 14,
            HasShadow = false,
            Padding = new Thickness(16),
            Content = new HorizontalStackLayout
            {
                Spacing = 12,
                Children =
                {
                    new Label { Text = icon, FontSize = 24, VerticalOptions = LayoutOptions.Center },
                    new VerticalStackLayout
                    {
                        Spacing = 3,
                        Children =
                        {
                            new Label { Text = title, TextColor = Colors.White, FontAttributes = FontAttributes.Bold },
                            new Label { Text = status, TextColor = Color.FromArgb(statusColor), FontSize = 13 }
                        }
                    }
                }
            }
        };
    }
}