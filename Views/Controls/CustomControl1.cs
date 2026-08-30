using Xamarin.Forms;

namespace BlackHawk.Views.Controls
{
    public class CustomControl1 : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomControl1), "");

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public CustomControl1()
        {
            Content = new Label { Text = Title };
        }
    }
}
