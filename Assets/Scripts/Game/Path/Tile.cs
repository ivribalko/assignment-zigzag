using System;
using UnityEngine;
using Zenject;
using ZigZag.Game.Anim;

namespace ZigZag.Game.Path
{
    internal class Tile : MonoBehaviour, ITile, IPoolable<Vector3>
    {
        public event Action OnDespawnOnce;

        public Bounds Bounds => new Bounds(this.Position, this.Scale);

        public Vector3 Scale => this.transform.localScale;

        public Vector3 Position
        {
            get => this.transform.localPosition;
            set => this.transform.localPosition = value;
        }

        private IHide hide;

        [Inject]
        private void Inject(IHide hide)
        {
            this.hide = hide;
        }

        public void OnSpawned(Vector3 p1)
        {
            this.transform.localScale = p1;
        }

        public void OnDespawned()
        {
            this.HideCease();

            this.OnDespawnOnce?.Invoke();
            this.OnDespawnOnce = null;
        }

        public void HideStart()
        {
            this.hide.HideStart();
        }

        public void HideCease()
        {
            this.hide.HideCease();
        }

        public void SetChild(Transform transform)
        {
            transform.SetParent(this.transform);
        }
    }
}