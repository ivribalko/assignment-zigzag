using System;
using ZigZag.Game.User;

namespace ZigZag.Game
{
    internal partial class Main
    {
        internal class InitialState : State, IDisposable
        {
            private readonly IInput input;

            private bool touched;

            public InitialState(IInput input)
            {
                this.input = input;

                this.input.OnTouch += this.OnTouch;
            }

            public void Dispose()
            {
                this.input.OnTouch -= this.OnTouch;
            }

            internal override void Start()
            {
                this.touched = false;
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
}