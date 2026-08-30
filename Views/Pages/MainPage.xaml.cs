using Microsoft.Maui.Controls;

namespace BlackHawk.Views.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnConfigureClicked(object? sender, EventArgs e)
    {
        StatusLabel.Text = "Yapılandırma için config.json dosyasını doldurun.";
    }
}