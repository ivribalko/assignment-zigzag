using UnityEngine;
using Zenject;

namespace ZigZag.Game.Path
{
    internal class Tile : MonoBehaviour, ITile, IPoolable<Vector3, Vector3>
    {
        public Bounds Bounds => new Bounds(this.Position, this.Scale);

        public Vector3 Scale => this.transform.localScale;

        public Vector3 Position => this.transform.localPosition;

        public void OnSpawned(Vector3 p1, Vector3 p2)
        {
            this.transform.localScale = p1;
            this.transform.localPosition = p2;
        }

        public void OnDespawned() { }
    }
}