using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl17 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl17), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl17()
        {
            Content = new Label { Text = Title };
        }
    }
}
