using System;
using System.Collections.Generic;
using ZigZag.Game.Opts;
using ZigZag.Game.Path;

namespace ZigZag.Game.Loot
{
    internal class Generator : IDisposable
    {
        private readonly IPath path;
        private readonly IOpts opts;
        private readonly ItemPool pool;

        private Strategy strategy;

        private Generator(
            IPath path,
            IOpts opts,
            ItemPool pool)
        {
            this.path = path;
            this.opts = opts;
            this.pool = pool;

            this.path.OnBlockSpawned += SpawnLoot;
        }

        public void Dispose()
        {
            this.path.OnBlockSpawned -= SpawnLoot;
        }

        private void SpawnLoot(IReadOnlyList<ITile> tiles)
        {
            var tile = this.strategy.Pick(tiles);

            var loot = this.pool.Spawn(tile);

            tile.OnDespawnOnce += () => this.pool.Despawn(loot);
        }
    }
}