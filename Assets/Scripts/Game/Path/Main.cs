using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ZigZag.Game.Path
{
    internal class Main : IPath
    {
        private readonly MemoryPool<ITile> pool;
        private readonly LinkedList<ITile> tiles = new LinkedList<ITile>();

        public Main(TilePool pool)
        {
            this.pool = pool;
        }

        public void SetCamera(Bounds bounds)
        {
            for (int i = 0; i < 10; i++)
            {
                var tile = this.pool.Spawn();

                this.tiles.AddLast(tile);
            }
        }

        public void Move(Vector2 movement)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            foreach (var item in this.tiles)
            {
                this.pool.Despawn(item);
            }

            this.tiles.Clear();
        }
    }
}