using System;
using ZigZag.Game.User;

namespace ZigZag.Game.Loop
{
    internal abstract class State : IDisposable
    {
        private readonly IInput input;

        private bool touched;

        protected State(IInput input)
        {
            this.input = input;

            this.input.OnTouch += this.OnTouch;
        }

        public void Dispose()
        {
            this.input.OnTouch -= this.OnTouch;
        }

        internal virtual void Start()
        {
            this.touched = false;
        }

        internal virtual bool Ended()
        {
            return this.touched;
        }

        internal virtual void OnTouch()
        {
            this.touched = true;
        }
    }
}