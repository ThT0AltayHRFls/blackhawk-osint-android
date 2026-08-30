using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl3 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl3), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl3()
        {
            Content = new Label { Text = Title };
        }
    }
}
