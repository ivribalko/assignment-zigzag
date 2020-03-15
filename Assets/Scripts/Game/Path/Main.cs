using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using ZigZag.Game.Opts;
using ZigZag.Game.User;
using ZigZag.Rife;

namespace ZigZag.Game.Path
{
    internal class Main : IPath
    {
        private readonly IOpts opts;
        private readonly TilePool pool;
        private readonly ICamera camera;
        private readonly Vector3 startDirection;
        private readonly RandomAccessArray<Vector3> directions;
        private readonly LinkedList<Tile> tiles = new LinkedList<Tile>();

        private Vector3 size;

        public Main(
            IOpts opts,
            TilePool pool,
            ICamera camera,
            RandomAccessArray<Vector3> directions)
        {
            this.opts = opts;
            this.pool = pool;
            this.camera = camera;
            this.directions = directions;
            this.startDirection = opts.Directions[0];
        }

        public ITile Start()
        {
            Assert.IsNull(this.tiles.Last);

            var factor = this.opts.TileFactor;

            this.size = this.TileOfFactor(factor);

            // first tile is 3 times bigger
            var start = this.SpawnNext(this.TileOfFactor(factor * 3), Vector3.zero);

            this.SpawnNext(this.size, this.startDirection);

            this.SpawnNext(this.size, this.startDirection);

            this.SpawnVisible();

            return start;
        }

        public void Progress(Vector3 movement)
        {
            foreach (var tile in this.tiles)
            {
                tile.Position -= movement;
            }

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
            while (!this.camera.Touches(this.tiles.First.Value.Bounds))
            {
                this.pool.Despawn(this.tiles.First.Value);

                this.tiles.RemoveFirst();
            }
        }

        private void SpawnVisible()
        {
            while (this.camera.Touches(this.tiles.Last.Value.Bounds))
            {
                this.SpawnNext(this.size, this.directions.Next());
            }
        }

        private ITile SpawnNext(Vector3 scale, Vector3 direction)
        {
            var last = this.tiles.Last?.Value;

            var tile = this.pool.Spawn(scale);

            tile.transform.PositionAt(
                bounds: last?.Bounds ?? default,
                direction : direction);

            this.tiles.AddLast(tile);

            return tile;
        }

        // Keep the same height.
        private Vector3 TileOfFactor(float factor)
        {
            var size = this.opts.TileSize;

            return new Vector3(
                size.x * factor,
                size.y,
                size.z * factor);
        }
    }
}