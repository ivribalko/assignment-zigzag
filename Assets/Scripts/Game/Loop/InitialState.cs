using System;
using UnityEngine;
using ZigZag.Game.Ball;
using ZigZag.Game.Path;
using ZigZag.Game.User;

namespace ZigZag.Game.Loop
{
    internal class InitialState : State, IDisposable
    {
        private readonly IInput input;
        private readonly IPath path;
        private readonly IBall ball;

        private bool touched;

        public InitialState(
            IInput input,
            IPath path,
            IBall ball)
        {
            this.input = input;
            this.path = path;
            this.ball = ball;

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

            this.ball.SetSpeed(0);
            this.ball.Position = Vector3.zero;
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