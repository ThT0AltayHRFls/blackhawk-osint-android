using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlackHawk.Animation
{
    public static class AnimationHelper
    {
        public static async Task FadeInAsync(VisualElement element, uint duration = 250)
        {
            element.Opacity = 0;
            await element.FadeTo(1, duration);
        }

        public static async Task FadeOutAsync(VisualElement element, uint duration = 250)
        {
            await element.FadeTo(0, duration);
            element.IsVisible = false;
        }

        public static async Task ScaleAsync(VisualElement element, double scale = 1.2, uint duration = 250)
        {
            await element.ScaleTo(scale, duration);
        }

        public static async Task TranslateAsync(VisualElement element, double x, double y, uint duration = 250)
        {
            await element.TranslateTo(x, y, duration);
        }

        public static async Task BounceAsync(VisualElement element)
        {
            await element.ScaleTo(1.1, 100);
            await element.ScaleTo(1, 100);
        }
    }
}
