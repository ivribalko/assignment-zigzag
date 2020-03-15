using UnityEngine;
using Zenject;
using ZigZag.Game.User;

namespace ZigZag.Game.Gain
{
    public sealed class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .BindInterfacesAndSelfTo<View>()
                .FromComponentInNewPrefabResource("Gain")
                .UnderTransform(_ => Object.FindObjectOfType<UserCamera>().transform)
                .AsSingle();

            this.Container
                .Bind<Main>()
                .AsSingle();

            this.Container
                .Bind<Bind>()
                .AsSingle()
                .NonLazy();
        }
    }
}