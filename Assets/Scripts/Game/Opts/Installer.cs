using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ZigZag.Game.Opts
{
    public sealed class Installer : Installer<Installer>
    {
        public override void InstallBindings()
        {
            this.Container
                .Bind<IOpts>()
                .To<Opts>()
                .FromScriptableObjectResource("Opts")
                .AsSingle();
        }
    }
}