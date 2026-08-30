using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl16 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl16), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl16()
        {
            Content = new Label { Text = Title };
        }
    }
}
