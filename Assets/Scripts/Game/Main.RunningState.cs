using UnityEngine;

namespace ZigZag.Game
{
    internal partial class Main
    {
        internal class RunningState : State
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
}