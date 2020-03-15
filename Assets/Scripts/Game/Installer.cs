using UnityEngine;
using Zenject;

namespace ZigZag.Game
{
    public sealed class Installer : MonoInstaller
    {
        [SerializeField] Ball.Main ball;
        [SerializeField] new User.UserCamera camera;

        public override void InstallBindings()
        {
            this.Container
                .Bind<Ball.IBall>()
                .FromInstance(this.ball);

            this.Container
                .Bind<User.ICamera>()
                .FromInstance(this.camera);

            this.BindFromSubcontainer<Anim.IHide, Anim.Installer>();

            this.BindFromSubcontainer<Opts.IOpts, Opts.Installer>();

            this.BindFromSubcontainer<Path.IPath, Path.Installer>();

            this.BindFromSubcontainer<Loot.ILoot, Loot.Installer>();

            this.BindFromSubcontainer<User.Input, User.Installer>();

            this.BindFromSubcontainer<Loop.Main, Loop.Installer>()
                .NonLazy();
        }

        private ConcreteIdArgConditionCopyNonLazyBinder BindFromSubcontainer<TType, TInstaller>() where TInstaller : InstallerBase
        {
            return this.Container
                .BindInterfacesAndSelfTo<TType>()
                .FromSubContainerResolve()
                .ByInstaller<TInstaller>()
                .AsSingle();
        }
    }
}