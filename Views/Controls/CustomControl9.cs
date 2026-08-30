using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl9 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl9), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl9()
        {
            Content = new Label { Text = Title };
        }
    }
}
