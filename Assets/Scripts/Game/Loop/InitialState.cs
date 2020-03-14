using System;
using ZigZag.Game.Path;
using ZigZag.Game.User;

namespace ZigZag.Game.Loop
{
    internal class InitialState : State, IDisposable
    {
        private readonly IInput input;
        private readonly IPath path;

        private bool touched;

        public InitialState(IInput input, IPath path)
        {
            this.input = input;
            this.path = path;
            this.input.OnTouch += this.OnTouch;
        }

        public void Dispose()
        {
            this.input.OnTouch -= this.OnTouch;
        }

        internal override void Start()
        {
            this.touched = false;

            this.path.Clear();
            this.path.Start();
        }

        internal override bool Ended()
        {
            return this.touched;
        }

        private void OnTouch()
        {
            this.touched = true;
        }
    }
}