using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl6 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl6), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl6()
        {
            Content = new Label { Text = Title };
        }
    }
}
