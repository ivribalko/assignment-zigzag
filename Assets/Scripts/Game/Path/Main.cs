using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ZigZag.Game.Path
{
    internal class Main : IPath
    {
        private readonly MemoryPool<Vector3, Tile> pool;
        private readonly LinkedList<Tile> tiles = new LinkedList<Tile>();

        public Main(TilePool pool)
        {
            this.pool = pool;
        }

        public void SetCamera(Bounds bounds)
        {
            if (this.tiles.Last == null)
            {
                var tile = this.pool.Spawn(Vector3.one * 3);

                this.tiles.AddLast(tile);
            }

            for (int i = 0; i < 10; i++)
            {
                var tile = this.pool.Spawn(Vector3.one);

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