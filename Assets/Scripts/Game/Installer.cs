using UnityEngine;
using Zenject;
using ZigZag.Game.Ball;
using ZigZag.Game.User;

namespace ZigZag.Game
{
    public sealed class Installer : MonoInstaller
    {
        [SerializeField] Ball.Main ball;
        [SerializeField] new UserCamera camera;

        public override void InstallBindings()
        {
            Anim.Installer.Install(this.Container);

            Path.Installer.Install(this.Container);

            Opts.Installer.Install(this.Container);

            User.Installer.Install(this.Container, this.camera);

            this.Container
                .Bind<IBall>()
                .FromInstance(this.ball);

            this.Container
                .BindInterfacesTo<Loop.Main>()
                .FromSubContainerResolve()
                .ByInstaller<Loop.Installer>()
                .AsSingle()
                .NonLazy();
        }
    }
}