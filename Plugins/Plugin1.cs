using System;

namespace BlackHawk.Plugins
{
    public interface IPlugin1
    {
        void Initialize();
        void Execute();
    }

    public class Plugin1 : IPlugin1
    {
        public void Initialize()
        {
        }

        public void Execute()
        {
        }
    }
}
