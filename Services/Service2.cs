using System;
using System.Threading.Tasks;

namespace BlackHawk.Services
{
    public class Service2
    {
        public async Task ExecuteAsync()
        {
            await Task.Delay(100);
        }
    }
}
