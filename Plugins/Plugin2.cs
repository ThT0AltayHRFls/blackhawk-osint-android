using System;

namespace BlackHawk.Plugins
{
    public interface IPlugin2
    {
        void Initialize();
        void Execute();
    }

    public class Plugin2 : IPlugin2
    {
        public void Initialize()
        {
        }

        public void Execute()
        {
        }
    }
}
