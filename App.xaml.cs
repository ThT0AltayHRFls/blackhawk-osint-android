using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace BlackHawk
{
    public partial class App : Application
    {
        public App()
        {
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new StartupPage());
        }
    }
}
