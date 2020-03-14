using UnityEngine;
using Zenject;

namespace ZigZag.Game.Path
{
    internal class Tile : MonoBehaviour, ITile, IPoolable<Vector3>
    {
        public Bounds Bounds =>
        throw new System.NotImplementedException();

        public Vector3 Scale
        {
            get => this.transform.localScale;
            private set => this.transform.localScale = value;
        }

        public Vector3 Position
        {
            get =>
                throw new System.NotImplementedException();
            set =>
                throw new System.NotImplementedException();
        }

        public void OnSpawned(Vector3 p1)
        {
            this.Scale = p1;
        }

        public void OnDespawned()
        { }
    }
}