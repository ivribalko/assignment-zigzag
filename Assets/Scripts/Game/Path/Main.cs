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

            this.Spawn(new Vector3(
                    this.size.x * 3,
                    this.size.y,
                    this.size.z * 3))
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

                this.tiles.RemoveFirst();
            }
        }

        private void SpawnVisible()
        {
            while (this.camera.Envelopes(this.tiles.Last.Value.Bounds))
            {
                var last = this.tiles.Last.Value;

                var tile = this.Spawn(this.size);

                tile.Position = PositionNear(
                    parent: last,
                    target: tile,
                    this.directions.Next());
            }
        }

        private Tile Spawn(Vector3 scale)
        {
            var tile = this.pool.Spawn(scale);

            this.tiles.AddLast(tile);

            return tile;
        }

        private Vector3 PositionNear(Tile parent, Tile target, Vector3 direction)
        {
            var scaleOne = parent.Scale;
            var scaleTwo = target.Scale;

            var diff = (scaleOne + scaleTwo) / 2;

            diff.Scale(direction);

            return parent.Position + diff;
        }
    }
}