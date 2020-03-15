using System.Collections.Generic;
using ZigZag.Game.Path;

namespace ZigZag.Game.Loot
{
    internal abstract class Strategy
    {
        internal abstract ITile Pick(IReadOnlyList<ITile> tiles);
    }
}