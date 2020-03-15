using System.Collections.Generic;
using UnityEngine;

namespace ZigZag.Game.Opts
{
    public interface IOpts
    {
        /// <summary>
        /// Direction where ball can go.
        /// </summary>
        IReadOnlyList<Vector3> Directions { get; }

        /// <summary>
        /// How large the tiles are.
        /// </summary>
        Vector3 TileSize { get; }

        /// <summary>
        /// How large the path is. The less it is the more the difficulty.
        /// </summary>
        float TileFactor { get; }

        /// <summary>
        /// How fast the ball is.
        /// </summary>
        float BallSpeed { get; }

        /// <summary>
        /// Ball size respective to tiles.
        /// </summary>
        float BallToTile { get; }

        /// <summary>
        /// How loot is generated.
        /// </summary>
        Game.Opts.Loot LootStrategy { get; }

        /// <summary>
        /// Tiles per one block. One loot per block.
        /// </summary>
        int LootBlock { get; }
    }
}