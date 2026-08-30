using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace BlackHawk.Hardware
{
    public class LocationService
    {
        public async Task<Location> GetCurrentLocationAsync()
        {
            return await Geolocation.GetLocationAsync();
        }
    }
}
