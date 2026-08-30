using System;
using System.Threading.Tasks;

namespace BlackHawk.Hardware
{
    public class CameraService
    {
        public async Task<byte[]> TakePictureAsync()
        {
            await Task.Delay(100);
            return null;
        }
    }
}
