using ZigZag.Game.Ball;
using ZigZag.Game.User;

namespace ZigZag.Game.Loop
{
    internal class FinishedState : State
    {
        private readonly IBall ball;

        public FinishedState(
            IInput input,
            IBall ball) : base(input)
        {
            this.ball = ball;
        }

        internal override void Start()
        {
            base.Start();

            this.ball.Disappear();
        }
    }
}