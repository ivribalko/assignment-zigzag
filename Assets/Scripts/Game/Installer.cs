using UnityEngine;
using Zenject;

namespace ZigZag.Game
{
    public sealed class Installer : MonoInstaller
    {
        [SerializeField] new User.UserCamera camera;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(this.Container);

            this.Container.DeclareSignal<SignalPick>();

            this.Container.DeclareSignal<SignalReset>();

            this.Container.Bind<User.ICamera>().FromInstance(this.camera);

            this.BindTypeFromSubcontainerByInstaller<Anim.IHide, Anim.Installer>();

            this.BindTypeFromSubcontainerByInstaller<Opts.IOpts, Opts.Installer>();

            this.BindTypeFromSubcontainerByInstaller<Path.IPath, Path.Installer>();

            this.BindTypeFromSubcontainerByInstaller<User.Input, User.Installer>();

            this.BindTypeFromSubcontainerByInstaller<Menu.IView, Gain.Installer>();

            this.BindTypeFromSubcontainerByInstaller<Loot.ILoot, Loot.Installer>()
                .NonLazy();

            this.BindTypeFromSubcontainerByInstaller<Loop.Main, Loop.Installer>()
                .NonLazy();
        }

        private ConcreteIdArgConditionCopyNonLazyBinder BindTypeFromSubcontainerByInstaller<TType, TInstaller>() where TInstaller : InstallerBase
        {
            return this.Container
                .BindInterfacesAndSelfTo<TType>()
                .FromSubContainerResolve()
                .ByInstaller<TInstaller>()
                .AsSingle();
        }
    }
}