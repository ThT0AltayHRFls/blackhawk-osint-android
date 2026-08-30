using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl11 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl11), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl11()
        {
            Content = new Label { Text = Title };
        }
    }
}
