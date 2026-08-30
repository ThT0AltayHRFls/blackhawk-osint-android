using Xamarin.Forms;
using Xamarin.Essentials;

namespace BlackHawk.Utils
{
    public static class DeviceInfoUtil
    {
        public static string GetDeviceModel()
        {
            return DeviceInfo.Model;
        }

        public static string GetDeviceManufacturer()
        {
            return DeviceInfo.Manufacturer;
        }

        public static string GetOsVersion()
        {
            return DeviceInfo.VersionString;
        }

        public static string GetDevicePlatform()
        {
            return DeviceInfo.Platform.ToString();
        }

        public static DisplayInfo GetDisplayInfo()
        {
            return DeviceDisplay.Current.MainDisplayInfo;
        }

        public static bool IsLandscape()
        {
            return DeviceDisplay.Current.MainDisplayInfo.Orientation == DisplayOrientation.Landscape;
        }

        public static bool IsPortrait()
        {
            return DeviceDisplay.Current.MainDisplayInfo.Orientation == DisplayOrientation.Portrait;
        }
    }
}
