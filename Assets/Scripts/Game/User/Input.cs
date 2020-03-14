using System;
using Zenject;

namespace ZigZag.Game.User
{
    internal class Input : IInput, ITickable
    {
        public event Action OnTouch;

        public void Tick()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                this.OnTouch?.Invoke();
            }
        }
    }
}