using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using ZigZag.Game.User;

namespace ZigZag.Game.Path
{
    internal class Main : IPath
    {
        private readonly TilePool pool;
        private readonly Bounds cameraBounds;
        private readonly LinkedList<Tile> tiles = new LinkedList<Tile>();

        public Main(
            TilePool pool,
            ICamera camera)
        {
            this.pool = pool;
            this.cameraBounds = camera.GetBounds();
        }

        public void Start()
        {
            Assert.IsNull(this.tiles.Last);

            this.Spawn(
                scale: Vector3.one * 3,
                position: Vector3.zero);

            this.SpawnVisible();
        }

        public void Move(Vector2 movement)
        {
            this.DespawnInvisible();

            this.SpawnVisible();
        }

        public void Clear()
        {
            foreach (var item in this.tiles)
            {
                this.pool.Despawn(item);
            }

            this.tiles.Clear();
        }

        private void DespawnInvisible()
        {
            while (!this.Visible(this.tiles.First.Value))
            {
                this.pool.Despawn(this.tiles.First.Value);
            }
        }

        private void SpawnVisible()
        {
            while (this.Visible(this.tiles.Last.Value))
            {
                var last = this.tiles.Last.Value;

                var size = Vector3.one;

                this.Spawn(
                    scale: size,
                    position: last.Position + last.Scale / 2 + size / 2);
            }
        }

        private bool Visible(ITile tile)
        {
            return this.Visible(tile.Bounds.min) || this.Visible(tile.Bounds.max);
        }

        private bool Visible(Vector3 point)
        {
            return this.cameraBounds.Contains(point);
        }

        private void Spawn(Vector3 scale, Vector3 position)
        {
            var tile = this.pool.Spawn(scale, position);

            this.tiles.AddLast(tile);
        }
    }
}