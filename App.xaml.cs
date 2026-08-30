using Microsoft.Maui.Controls;

namespace BlackHawk
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
