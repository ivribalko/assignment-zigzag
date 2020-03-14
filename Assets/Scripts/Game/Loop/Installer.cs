using Zenject;

namespace ZigZag.Game.Loop
{
    internal class Installer : Installer<Installer>
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
                .BindInterfacesTo<Main>()
                .AsSingle()
                .NonLazy();
        }
    }
}