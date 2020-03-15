using System.Collections;
using UnityEngine;
using Zenject;

namespace ZigZag.Game.Path
{
    internal class Tile : MonoBehaviour, ITile, IPoolable<Vector3>
    {
        const float DisappearIn = 2f;

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

        public void Disappear()
        {
            StartCoroutine(MoveCoroutine(Vector3.down * 3f));
        }

        private IEnumerator MoveCoroutine(Vector3 move)
        {
            var remaining = DisappearIn;

            while ((remaining -= Time.deltaTime) > 0)
            {
                this.Position += move * (DisappearIn - remaining);

                yield return null;
            }
        }
    }
}