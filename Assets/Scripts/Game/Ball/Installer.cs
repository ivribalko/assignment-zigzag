using UnityEngine;
using Zenject;

namespace ZigZag.Game.Ball
{
    public sealed class Installer : MonoInstaller<Installer>
    {
        [SerializeField] Main ball;

        public override void InstallBindings()
        {
            this.Container
                .Bind<IBall>()
                .FromInstance(this.ball);
        }
    }
}