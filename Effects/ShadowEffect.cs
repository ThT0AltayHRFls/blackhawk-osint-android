using Xamarin.Forms;

namespace BlackHawk.Effects
{
    public static class ShadowEffect
    {
        public static float GetRadius(BindableObject bindable)
        {
            return (float)bindable.GetValue(RadiusProperty);
        }

        public static void SetRadius(BindableObject bindable, float value)
        {
            bindable.SetValue(RadiusProperty, value);
        }

        public static readonly BindableProperty RadiusProperty =
            BindableProperty.CreateAttached(
                "Radius",
                typeof(float),
                typeof(ShadowEffect),
                5.0f);

        public static Color GetColor(BindableObject bindable)
        {
            return (Color)bindable.GetValue(ColorProperty);
        }

        public static void SetColor(BindableObject bindable, Color value)
        {
            bindable.SetValue(ColorProperty, value);
        }

        public static readonly BindableProperty ColorProperty =
            BindableProperty.CreateAttached(
                "Color",
                typeof(Color),
                typeof(ShadowEffect),
                Color.Black);
    }
}
