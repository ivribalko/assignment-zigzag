using Zenject;

namespace ZigZag.Game.Loot
{
    public sealed class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .BindMemoryPool<Item, ItemPool>()
                .FromComponentInNewPrefabResource("LootItem");
        }
    }
}