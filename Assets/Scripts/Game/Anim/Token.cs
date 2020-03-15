using System;

namespace ZigZag.Game.Anim
{
    public class Token : IDisposable
    {
        public bool Disposed;

        public void Dispose()
        {
            this.Disposed = true;
        }
    }
}