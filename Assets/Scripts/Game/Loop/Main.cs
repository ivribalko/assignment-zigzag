using Zenject;
using ZigZag.Rife;

namespace ZigZag.Game.Loop
{
    internal class Main : ITickable
    {
        private readonly CircularArray<State> states;

        private Main(
            InitialState initial,
            RunningState running,
            FinishedState finished)
        {
            this.states = new CircularArray<State>(new State[]
            {
                initial,
                running,
                finished,
            });

            this.states
                .Current
                .Start();
        }

        public void Tick()
        {
            if (this.states.Current.Ended())
            {
                this.states
                    .Next()
                    .Start();
            }
        }
    }
}