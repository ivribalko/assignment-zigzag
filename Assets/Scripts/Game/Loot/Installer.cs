using System;
using Zenject;
using ZigZag.Game.Opts;

namespace ZigZag.Game.Loot
{
    public sealed class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .BindMemoryPool<Item, ItemPool>()
                .FromComponentInNewPrefabResource("Item")
                .UnderTransformGroup("Loot")
                .AsSingle();

            this.Container
                .BindInterfacesTo<Main>()
                .AsSingle();

            this.Container
                .BindIFactory<Strategy>()
                .FromResolveGetter<IOpts>(this.GetStrategy);
        }

        private Strategy GetStrategy(IOpts opts)
        {
            switch (opts.LootStrategy)
            {
                case Opts.Loot.Random:
                    return new StrategyRandom();
                case Opts.Loot.Ordered:
                    return new StrategyOrdered();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}