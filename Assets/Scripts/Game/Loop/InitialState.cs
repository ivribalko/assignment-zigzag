using ZigZag.Game.Ball;
using ZigZag.Game.Opts;
using ZigZag.Game.Path;
using ZigZag.Game.User;

namespace ZigZag.Game.Loop
{
    internal class InitialState : State
    {
        private readonly IPath path;
        private readonly IBall ball;
        private readonly IOpts opts;

        public InitialState(
            IInput input,
            IPath path,
            IBall ball,
            IOpts opts) : base(input)
        {
            this.path = path;
            this.ball = ball;
            this.opts = opts;
        }

        internal override void Start()
        {
            base.Start();

            this.path.Clear();

            var tile = this.path.Start();
            var size = this.opts.TileSize * this.opts.BallToTile;

            this.ball.HideCease();
            this.ball.SetSpeed(0);
            this.ball.SetSize(size);
            this.ball.SetPosition(tile);
        }
    }
}