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

        public Main(
            TilePool pool,
            ICamera camera,
            RandomAccessArray<Vector3> directions)
        {
            this.pool = pool;
            this.camera = camera;
            this.directions = directions;
        }

        public void Start()
        {
            Assert.IsNull(this.tiles.Last);

            this.Spawn(this.size * 3)
                .Position = Vector3.zero;

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
            while (!this.camera.Touches(this.tiles.First.Value.Bounds))
            {
                this.pool.Despawn(this.tiles.First.Value);
            }
        }

        private void SpawnVisible()
        {
            while (this.camera.Touches(this.tiles.Last.Value.Bounds))
            {
                var last = this.tiles.Last.Value;

                var tile = this.Spawn(this.size);

                foreach (var direction in this.directions)
                {
                    tile.Position = Position(last, tile, direction);

                    if (this.camera.Contains(tile.Bounds))
                    {
                        break;
                    }
                }
            }
        }

        private Tile Spawn(Vector3 scale)
        {
            var tile = this.pool.Spawn(scale);

            this.tiles.AddLast(tile);

            return tile;
        }

        private Vector3 Position(Tile one, Tile two, Vector3 direction)
        {
            var scaleOne = one.Scale;
            var scaleTwo = two.Scale;

            var diff = new Vector3(
                (scaleOne.x + scaleTwo.x) * direction.x / 2,
                (scaleOne.y + scaleTwo.y) * direction.y / 2,
                (scaleOne.z + scaleTwo.z) * direction.z / 2);

            return one.Position + diff;
        }
    }
}