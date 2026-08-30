using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl14 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl14), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl14()
        {
            Content = new Label { Text = Title };
        }
    }
}
