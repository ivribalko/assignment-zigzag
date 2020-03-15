using Zenject;
using ZigZag.Game.Path;

namespace ZigZag.Game.Loot
{
    internal class ItemPool : MonoPoolableMemoryPool<ITile, Item>
    {
        protected override void OnCreated(Item item)
        {
            base.OnCreated(item);

            item.OnCollision += this.Despawn;
        }
    }
}