using System;
using Zenject;
using ZigZag.Game.Ball;
using ZigZag.Game.Opts;
using ZigZag.Game.Path;
using ZigZag.Game.User;

namespace ZigZag.Game
{
    public class Main : ITickable, IDisposable
    {
        private readonly IPath path;
        private readonly IBall ball;
        private readonly IOpts opts;
        private readonly IInput input;
        private readonly ICamera camera;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Tick()
        {
            throw new NotImplementedException();
        }

        private void Reset()
        {
            throw new NotImplementedException();
        }
    }
}