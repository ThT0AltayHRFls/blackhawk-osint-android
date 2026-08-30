using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl4 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl4), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl4()
        {
            Content = new Label { Text = Title };
        }
    }
}
