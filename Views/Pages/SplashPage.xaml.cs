using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlackHawk.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
            NavigateAsync();
        }

        private async void NavigateAsync()
        {
            await System.Threading.Tasks.Task.Delay(3000);
            bool isFirstRun = Xamarin.Essentials.Preferences.Get("FirstRun", true);
            
            if (isFirstRun)
            {
                await Shell.Current.GoToAsync("onboarding");
            }
            else
            {
                await Shell.Current.GoToAsync("search");
            }
        }
    }
}
