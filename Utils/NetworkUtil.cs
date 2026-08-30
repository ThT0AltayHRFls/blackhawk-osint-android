using System.Threading.Tasks;
using Xamarin.Essentials;

namespace BlackHawk.Utils
{
    public static class NetworkUtil
    {
        public static async Task<bool> IsNetworkAvailableAsync()
        {
            try
            {
                var current = Connectivity.Current.NetworkAccess;
                return current == NetworkAccess.Internet;
            }
            catch
            {
                return false;
            }
        }

        public static NetworkAccess GetNetworkAccess()
        {
            return Connectivity.Current.NetworkAccess;
        }

        public static bool HasInternetConnection()
        {
            return GetNetworkAccess() == NetworkAccess.Internet;
        }
    }
}
