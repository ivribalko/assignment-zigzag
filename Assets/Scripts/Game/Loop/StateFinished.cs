using ZigZag.Game.Ball;
using ZigZag.Game.Menu;
using ZigZag.Game.User;

namespace ZigZag.Game.Loop
{
    internal class StateFinished : State
    {
        private readonly IView gain;
        private readonly IBall ball;

        public StateFinished(
            IInput input,
            IView gain,
            IBall ball) : base(input)
        {
            this.gain = gain;
            this.ball = ball;
        }

        internal override void Start()
        {
            base.Start();

            this.ball.HideStart();

            this.gain.Show();
        }
    }
}