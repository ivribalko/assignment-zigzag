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
                .WhenInjectedInto<StateRunning>();

            this.Container
                .Bind<StateInitial>()
                .WhenInjectedInto<Main>();

            this.Container
                .Bind<StateRunning>()
                .WhenInjectedInto<Main>();

            this.Container
                .Bind<StateFinished>()
                .WhenInjectedInto<Main>();

            this.Container
                .Bind<Main>()
                .AsSingle();
        }
    }
}