using UnityEngine;
using Zenject;

namespace ZigZag.Game.Path
{
    public class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .BindMemoryPool<ITile, TilePool>()
                .To<Tile>()
                .FromComponentInNewPrefabResource("Tile")
                .UnderTransformGroup("Path");

            this.Container
                .BindInterfacesTo<Main>()
                .AsSingle();
        }
    }
}