using UnityEngine;
using Zenject;

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

        public void OnSpawned(Vector3 p1)
        {
            this.transform.localScale = p1;
        }

        public void OnDespawned() { }
    }
}