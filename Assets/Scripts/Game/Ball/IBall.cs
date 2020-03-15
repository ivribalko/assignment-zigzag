using System;
using UnityEngine;
using ZigZag.Game.Path;

namespace ZigZag.Game.Ball
{
    public interface IBall
    {
        /// <summary>
        /// Send difference.
        /// </summary>
        event Action<Vector3> OnMoveUpdate;

        void SetSize(Vector3 size);

        void SetSpeed(float speed);

        void SetPosition(ITile tile);

        void SetDirection(Vector3 direction);

        T On<T>() where T : class;
    }
}