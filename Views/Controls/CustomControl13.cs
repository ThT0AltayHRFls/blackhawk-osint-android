using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl13 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl13), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl13()
        {
            Content = new Label { Text = Title };
        }
    }
}
