using Zenject;

namespace ZigZag.Game.Path
{
    internal class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .BindMemoryPool<Tile, TilePool>()
                .FromComponentInNewPrefabResource("Tile")
                .UnderTransformGroup("Path");

            this.Container
                .BindInterfacesTo<Main>()
                .AsSingle();
        }
    }
}