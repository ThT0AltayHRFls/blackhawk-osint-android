using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlackHawk.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnboardingPage : ContentPage
    {
        public OnboardingPage()
        {
            InitializeComponent();
        }

        private async void OnFinishClicked(object sender, System.EventArgs e)
        {
            Xamarin.Essentials.Preferences.Set("FirstRun", false);
            await Shell.Current.GoToAsync("search");
        }
    }
}
