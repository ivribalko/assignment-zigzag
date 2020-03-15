using System;
using UnityEngine;
using Zenject;

namespace ZigZag.Game.Anim
{
    public class Hider : MonoBehaviour, IHide
    {
        private IAnimator animator;

        private IDisposable disappearing;

        [Inject]
        private void Inject(IAnimator animator)
        {
            this.animator = animator;
        }

        public void HideStart()
        {
            if (this.disappearing != null)
            {
                throw new InvalidOperationException();
            }

            this.disappearing = this.animator.Disappear(this);
        }

        public void HideCease()
        {
            this.disappearing?.Dispose();
            this.disappearing = null;
        }
    }
}