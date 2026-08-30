using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl15 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl15), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl15()
        {
            Content = new Label { Text = Title };
        }
    }
}
