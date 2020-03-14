using UnityEngine;
using ZigZag.Game.Ball;
using ZigZag.Game.Path;
using ZigZag.Game.User;

namespace ZigZag.Game.Loop
{
    internal class InitialState : State
    {
        private readonly IPath path;
        private readonly IBall ball;

        public InitialState(
            IInput input,
            IPath path,
            IBall ball) : base(input)
        {
            this.path = path;
            this.ball = ball;
        }

        internal override void Start()
        {
            base.Start();

            this.path.Clear();
            this.path.Start();

            this.ball.SetSpeed(0);
            this.ball.Position = Vector3.zero;
        }
    }
}