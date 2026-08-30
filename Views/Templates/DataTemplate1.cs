using Xamarin.Forms;

namespace BlackHawk.Views.Templates
{
    public class DataTemplate1 : DataTemplate
    {
        public DataTemplate1() : base(() => new ContentView())
        {
        }
    }
}
