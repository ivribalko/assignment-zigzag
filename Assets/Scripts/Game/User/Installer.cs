using Zenject;

namespace ZigZag.Game.User
{
    public sealed class Installer : Installer<UserCamera, Installer>
    {
        [Inject]
        private UserCamera camera;

        public override void InstallBindings()
        {
            this.Container
                .BindInterfacesTo<UserCamera>()
                .FromInstance(this.camera);

            this.Container
                .BindInterfacesTo<User.Input>()
                .AsSingle()
                .NonLazy();
        }
    }
}