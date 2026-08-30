using Xamarin.Forms;

namespace BlackHawk.Effects
{
    public static class RippleEffect
    {
        public static Color GetRippleColor(BindableObject bindable)
        {
            return (Color)bindable.GetValue(RippleColorProperty);
        }

        public static void SetRippleColor(BindableObject bindable, Color value)
        {
            bindable.SetValue(RippleColorProperty, value);
        }

        public static readonly BindableProperty RippleColorProperty =
            BindableProperty.CreateAttached(
                "RippleColor",
                typeof(Color),
                typeof(RippleEffect),
                Color.Gray);
    }
}
