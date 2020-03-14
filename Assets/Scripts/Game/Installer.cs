using System.Collections.Generic;
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
            Loop.Installer.Install(this.Container);

            Path.Installer.Install(this.Container);

            User.Installer.Install(this.Container, this.camera);

            this.Container
                .Bind<IReadOnlyList<Vector3>>()
                .FromInstance(new [] { Vector3.left, Vector3.forward }); //TODO id

            this.Container
                .Bind<IBall>()
                .FromInstance(this.ball);

            this.Container
                .BindInstance(1f); //TODO settings
        }
    }
}