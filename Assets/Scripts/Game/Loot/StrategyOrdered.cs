using System.Collections.Generic;
using ZigZag.Game.Path;

namespace ZigZag.Game.Loot
{
    internal class StrategyOrdered : Strategy
    {
        private int index = -1;

        internal override ITile Pick(IReadOnlyList<ITile> tiles)
        {
            this.index += 1;

            this.index %= tiles.Count;

            return tiles[this.index];
        }
    }
}