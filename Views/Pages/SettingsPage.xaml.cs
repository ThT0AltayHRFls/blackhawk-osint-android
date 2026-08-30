using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BlackHawk.ViewModels;

namespace BlackHawk.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = new SettingsViewModel();
        }
    }
}
