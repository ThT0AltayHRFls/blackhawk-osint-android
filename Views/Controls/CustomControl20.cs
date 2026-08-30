using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl20 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl20), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl20()
        {
            Content = new Label { Text = Title };
        }
    }
}
