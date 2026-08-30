using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl7 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl7), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl7()
        {
            Content = new Label { Text = Title };
        }
    }
}
