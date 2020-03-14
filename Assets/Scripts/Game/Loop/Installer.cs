using UnityEngine;
using Zenject;
using ZigZag.Rife;

namespace ZigZag.Game.Loop
{
    public sealed class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
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
                .Bind<CircularArray<Vector3>>() //TODO directions -> id
                .AsTransient();

            this.Container
                .BindInterfacesTo<Main>()
                .AsSingle()
                .NonLazy();
        }
    }
}