using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZigZag.Game.Opts;
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
                .Bind<IReadOnlyList<Vector3>>()
                .FromResolveGetter<IOpts>(opts => opts.Directions)
                .WhenInjectedInto<RandomAccessArray<Vector3>>();

            this.Container
                .Bind<RandomAccessArray<Vector3>>()
                .WhenInjectedInto<Main>();
        }
    }
}