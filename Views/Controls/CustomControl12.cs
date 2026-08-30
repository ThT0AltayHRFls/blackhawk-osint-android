using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl12 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl12), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl12()
        {
            Content = new Label { Text = Title };
        }
    }
}
