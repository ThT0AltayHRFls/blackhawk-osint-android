using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl8 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl8), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl8()
        {
            Content = new Label { Text = Title };
        }
    }
}
