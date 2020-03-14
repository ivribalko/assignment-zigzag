using Zenject;
using ZigZag.Game;

public sealed class Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        this.Container
            .Bind<Main.InitialState>()
            .AsSingle();

        this.Container
            .Bind<Main.RunningState>()
            .AsSingle();

        this.Container
            .Bind<Main.FinishedState>()
            .AsSingle();

        this.Container
            .BindInterfacesTo<Main>()
            .AsSingle()
            .NonLazy();
    }
}