using System;
using System.Collections.Generic;
using ZigZag.Game.Path;

namespace ZigZag.Game.Loot
{
    internal class StrategyRandom : Strategy
    {
        private readonly Random random = new Random();

        internal override ITile Pick(IReadOnlyList<ITile> tiles)
        {
            return tiles[this.random.Next(tiles.Count)];
        }
    }
}