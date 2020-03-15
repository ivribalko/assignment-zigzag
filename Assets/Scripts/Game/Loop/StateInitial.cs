using Zenject;
using ZigZag.Game.Ball;
using ZigZag.Game.Loot;
using ZigZag.Game.Menu;
using ZigZag.Game.Opts;
using ZigZag.Game.Path;
using ZigZag.Game.User;

namespace ZigZag.Game.Loop
{
    internal class StateInitial : State
    {
        private readonly SignalBus signalBus;
        private readonly IPath path;
        private readonly IBall ball;
        private readonly IOpts opts;
        private readonly IView gain;
        private readonly ILoot loot;

        public StateInitial(
            SignalBus signalBus,
            IInput input,
            IPath path,
            IBall ball,
            IOpts opts,
            IView gain,
            ILoot loot) : base(input)
        {
            this.signalBus = signalBus;
            this.path = path;
            this.ball = ball;
            this.opts = opts;
            this.gain = gain;
            this.loot = loot;
        }

        internal override void Start()
        {
            base.Start();

            this.path.Clear();
            this.loot.Reset();
            this.gain.Hide();

            var tile = this.path.Start();
            var size = this.opts.TileSize * this.opts.BallToTile;

            this.ball.HideCease();
            this.ball.SetSpeed(0);
            this.ball.SetSize(size);
            this.ball.SetPosition(tile);

            this.signalBus.Fire<SignalReset>();
        }
    }
}