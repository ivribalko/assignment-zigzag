using Zenject;
using ZigZag.Game.Path;

namespace ZigZag.Game.Loot
{
    internal class ItemPool : MonoPoolableMemoryPool<ITile, Item>
    {
        private readonly SignalBus signalBus;

        public ItemPool(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        protected override void OnCreated(Item item)
        {
            base.OnCreated(item);

            item.OnCollision += this.SignalHit;

            item.OnCollision += this.Despawn;
        }

        protected override void OnDestroyed(Item item)
        {
            item.OnCollision -= this.SignalHit;

            item.OnCollision -= this.Despawn;

            base.OnDestroyed(item);
        }

        private void SignalHit(Item item)
        {
            this.signalBus.Fire<SignalPick>();
        }
    }
}