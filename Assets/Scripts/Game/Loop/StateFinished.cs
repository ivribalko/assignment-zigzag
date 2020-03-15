using ZigZag.Game.Ball;
using ZigZag.Game.User;

namespace ZigZag.Game.Loop
{
    internal class StateFinished : State
    {
        private readonly IBall ball;

        public StateFinished(
            IInput input,
            IBall ball) : base(input)
        {
            this.ball = ball;
        }

        internal override void Start()
        {
            base.Start();

            this.ball.HideStart();
        }
    }
}