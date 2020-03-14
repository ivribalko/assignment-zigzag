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
        private readonly Vector3 tileSize;

        public InitialState(
            IInput input,
            IPath path,
            IBall ball,
            Vector3 tileSize) : base(input)
        {
            this.path = path;
            this.ball = ball;
            this.tileSize = tileSize;
        }

        internal override void Start()
        {
            base.Start();

            this.path.Clear();

            var tile = this.path.Start();
            var size = this.tileSize / 2;

            this.ball.SetSpeed(0);
            this.ball.SetSize(size);
            this.ball.SetPosition(tile);
        }
    }
}