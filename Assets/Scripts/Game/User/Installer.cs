using Zenject;

namespace ZigZag.Game.User
{
    public sealed class Installer : Installer<UserCamera, Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .Bind<Input>()
                .AsSingle();
        }
    }
}