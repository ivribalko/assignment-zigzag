using UnityEngine;
using Zenject;
using ZigZag.Rife;

namespace ZigZag.Game.Path
{
    public sealed class Installer : Installer<Installer>
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

            this.Container
                .Bind<RandomAccessArray<Vector3>>()
                .AsSingle()
                .WithArguments(new [] { Vector3.forward, Vector3.left });
        }
    }
}