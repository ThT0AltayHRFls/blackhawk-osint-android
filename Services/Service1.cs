using System;
using System.Threading.Tasks;

namespace BlackHawk.Services
{
    public class Service1
    {
        public async Task ExecuteAsync()
        {
            await Task.Delay(100);
        }
    }
}
