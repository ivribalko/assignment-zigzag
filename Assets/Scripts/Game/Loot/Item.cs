using UnityEngine;
using Zenject;
using ZigZag.Game.Path;

namespace ZigZag.Game.Loot
{
    internal class Item : MonoBehaviour, IPoolable<ITile>
    {
        public void OnDespawned()
        {

        }

        public void OnSpawned(ITile p1)
        {

        }
    }
}