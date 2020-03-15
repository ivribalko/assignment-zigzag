using UnityEngine;
using ZigZag.Game.Ball;
using ZigZag.Game.Path;
using ZigZag.Game.User;
using ZigZag.Rife;

namespace ZigZag.Game.Loop
{
    internal class RunningState : State
    {
        private readonly IPath path;
        private readonly IBall ball;
        private readonly float speed;
        private readonly CircularArray<Vector3> directions;

        public RunningState(
            IInput input,
            IPath path,
            IBall ball,
            float speed,
            CircularArray<Vector3> directions) : base(input)
        {
            this.path = path;
            this.ball = ball;
            this.speed = speed;
            this.directions = directions;
        }

        internal override void Start()
        {
            base.Start();

            this.directions.Reset();

            this.ball.SetSpeed(this.speed);

            this.ball.SetDirection(this.directions.Next());

            this.ball.OnMoveUpdate += this.path.Progress;
        }

        internal override void OnTouch()
        {
            base.OnTouch();

            this.ball.SetDirection(this.directions.Next());
        }

        internal override bool Ended()
        {
            if (!this.ball.IsOn<ITile>())
            {
                this.ball.OnMoveUpdate -= this.path.Progress;

                this.ball.SetSpeed(0);

                return true;
            }

            return false;
        }
    }
}