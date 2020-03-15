using System;
using UnityEngine;
using Zenject;
using ZigZag.Game;
using ZigZag.Game.Path;

namespace ZigZag.Game.Loot
{
    internal class Item : MonoBehaviour, IPoolable<ITile>, IDespawnable
    {
        public event Action<Item> OnCollision;

        private ItemPool pool;

        [Inject]
        private void Inject(ItemPool pool)
        {
            this.pool = pool;
        }

        public void Despawn()
        {
            this.pool.Despawn(this);
        }

        public void OnDespawned()
        {

        }

        public void OnSpawned(ITile p1)
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            this.OnCollision?.Invoke(this);
        }
    }
}