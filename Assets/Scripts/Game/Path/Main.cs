using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using ZigZag.Game.User;
using ZigZag.Rife;

namespace ZigZag.Game.Path
{
    internal class Main : IPath
    {
        private readonly TilePool pool;
        private readonly ICamera camera;
        private readonly RandomAccessArray<Vector3> directions;
        private readonly LinkedList<Tile> tiles = new LinkedList<Tile>();

        private readonly Vector3 size = Vector3.one;
        private readonly Vector3 ballDirection;

        public Main(
            TilePool pool,
            ICamera camera,
            CircularArray<Vector3> ballDirections,
            RandomAccessArray<Vector3> directions)
        {
            this.pool = pool;
            this.camera = camera;
            this.directions = directions;
            this.ballDirection = ballDirections.Next();
        }

        public ITile Start()
        {
            Assert.IsNull(this.tiles.Last);

            var size = new Vector3(
                this.size.x * 3,
                this.size.y,
                this.size.z * 3);

            var start = this.SpawnNext(size, Vector3.zero);

            this.SpawnNext(this.size, this.ballDirection);

            this.SpawnNext(this.size, this.ballDirection);

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
    }
}