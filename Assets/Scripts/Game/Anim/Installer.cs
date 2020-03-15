using Zenject;

namespace ZigZag.Game.Anim
{
    public sealed class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .Bind<IAnimator>()
                .To<Animator>()
                .FromNewComponentOnRoot()
                .AsSingle();

            this.Container
                .Bind<IHide>()
                .To<Hider>()
                .FromNewComponentSibling();
        }
    }
}