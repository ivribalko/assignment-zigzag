using System;

namespace ZigZag.Rife
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