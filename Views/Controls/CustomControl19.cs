using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl19 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl19), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl19()
        {
            Content = new Label { Text = Title };
        }
    }
}
