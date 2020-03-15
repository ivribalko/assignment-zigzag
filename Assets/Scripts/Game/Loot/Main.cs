using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;
using ZigZag.Game.Path;

namespace ZigZag.Game.Loot
{
    internal class Main : IDisposable, ILoot
    {
        private readonly IPath path;
        private readonly ItemPool pool;
        private readonly IFactory<Strategy> pick;

        private Strategy strategy;

        private Main(
            IPath path,
            ItemPool pool,
            IFactory<Strategy> pick)
        {
            this.path = path;
            this.pool = pool;
            this.pick = pick;

            this.path.OnBlockSpawned += SpawnLoot;
        }

        public void Dispose()
        {
            this.path.OnBlockSpawned -= SpawnLoot;
        }

        public void Reset()
        {
            this.strategy = this.pick.Create();
        }

        private void SpawnLoot(IReadOnlyList<ITile> tiles)
        {
            var tile = this.strategy.Pick(tiles);

            Assert.IsNull(tile.GetComponentInChildren<Item>());

            var item = this.pool.Spawn(tile);

            item.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

            tile.SetChild(item.transform);

            item.transform.localPosition = new Vector3(0, 1f, 0);
        }
    }
}