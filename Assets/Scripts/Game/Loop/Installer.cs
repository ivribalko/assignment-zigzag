using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZigZag.Game.Opts;
using ZigZag.Rife;

namespace ZigZag.Game.Loop
{
    public sealed class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .Bind<IReadOnlyList<Vector3>>()
                .FromResolveGetter<IOpts>(opts => opts.Directions)
                .WhenInjectedInto<CircularArray<Vector3>>();

            this.Container
                .Bind<CircularArray<Vector3>>()
                .WhenInjectedInto<RunningState>();

            this.Container
                .Bind<InitialState>()
                .WhenInjectedInto<Main>();

            this.Container
                .Bind<RunningState>()
                .WhenInjectedInto<Main>();

            this.Container
                .Bind<FinishedState>()
                .WhenInjectedInto<Main>();

            this.Container
                .BindInterfacesTo<Main>()
                .AsSingle()
                .NonLazy();
        }
    }
}