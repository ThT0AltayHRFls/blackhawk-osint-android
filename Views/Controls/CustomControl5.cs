using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl5 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl5), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl5()
        {
            Content = new Label { Text = Title };
        }
    }
}
