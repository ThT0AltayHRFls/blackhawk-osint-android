using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl18 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl18), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl18()
        {
            Content = new Label { Text = Title };
        }
    }
}
