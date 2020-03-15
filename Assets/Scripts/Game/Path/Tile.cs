using System;
using UnityEngine;
using Zenject;
using ZigZag.Game.Anim;

namespace ZigZag.Game.Path
{
    internal class Tile : MonoBehaviour, ITile, IPoolable<Vector3>
    {
        public Bounds Bounds => new Bounds(this.Position, this.Scale);

        public Vector3 Scale => this.transform.localScale;

        public Vector3 Position
        {
            get => this.transform.localPosition;
            set => this.transform.localPosition = value;
        }

        private IAnimator animator;
        private IDisposable disappearing;

        [Inject]
        private void Inject(IAnimator animator)
        {
            this.animator = animator;
        }

        public void OnSpawned(Vector3 p1)
        {
            this.transform.localScale = p1;
        }

        public void OnDespawned()
        {
            this.disappearing?.Dispose();
            this.disappearing = null;
        }

        public void Disappear()
        {
            if (this.disappearing != null)
            {
                throw new InvalidOperationException();
            }

            this.disappearing = this.animator.Disappear(this);
        }
    }
}