using Zenject;
using ZigZag.Game.User;

public sealed class Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        ZigZag.Game.Loop.Installer.Install(this.Container);

        ZigZag.Game.Path.Installer.Install(this.Container);

        this.Container
            .BindInterfacesTo<Input>()
            .AsSingle()
            .NonLazy();
    }
}