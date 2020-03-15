using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZigZag.Game.Path;

namespace ZigZag.Game.Loot
{
    internal class Generator : IDisposable, ILoot
    {
        private readonly IPath path;
        private readonly ItemPool pool;
        private readonly IFactory<Strategy> pick;

        private Strategy strategy;

        private Generator(
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

            var loot = this.pool.Spawn(tile);

            tile.SetChild(loot.transform);

            loot.transform.localPosition = new Vector3(0, 1f, 0);
        }
    }
}