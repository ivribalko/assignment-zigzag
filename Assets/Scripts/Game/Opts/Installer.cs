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

            this.Container
                .Bind<IReadOnlyList<Vector3>>()
                .FromInstance(new [] { Vector3.right, Vector3.forward }); //TODO directions -> id

            this.Container
                .Bind<Vector3>()
                .FromInstance(Vector3.one); //TODO tile size -> id

            this.Container
                .Bind<float>()
                .FromInstance(2f); //TODO speed -> settings
        }
    }
}