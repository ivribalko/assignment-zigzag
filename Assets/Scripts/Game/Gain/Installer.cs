using UnityEngine;
using Zenject;
using ZigZag.Game.Menu;
using ZigZag.Game.User;

namespace ZigZag.Game.Gain
{
    public sealed class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .Bind<IView>()
                .FromComponentInNewPrefabResource("Gain")
                .UnderTransform(_ => Object.FindObjectOfType<UserCamera>().transform)
                .AsSingle();
        }
    }
}