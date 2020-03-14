using UnityEngine;

namespace ZigZag.Game.Loop
{
    internal class FinishedState : State
    {
        internal override void Start()
        {
            Debug.Log("Start " + this.GetType().Name);
        }

        internal override bool Ended()
        {
            Debug.Log("Ended " + this.GetType().Name);

            return true;
        }
    }
}