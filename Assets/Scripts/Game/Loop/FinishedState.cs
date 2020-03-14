using ZigZag.Game.User;

namespace ZigZag.Game.Loop
{
    internal class FinishedState : State
    {
        public FinishedState(IInput input) : base(input) { }

        internal override void Start()
        {
            base.Start();

            UnityEngine.Debug.Log(this.GetType().Name);
        }
    }
}