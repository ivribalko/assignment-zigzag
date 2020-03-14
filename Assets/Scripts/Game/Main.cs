using Zenject;
using ZigZag.Rife;

namespace ZigZag.Game
{
    internal partial class Main : ITickable
    {
        internal abstract class State
        {
            abstract internal void Start();
            abstract internal bool Ended();
        }

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