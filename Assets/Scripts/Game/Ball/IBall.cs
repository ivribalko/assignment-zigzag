using UnityEngine;
using ZigZag.Game.Path;

namespace ZigZag.Game.Ball
{
    public interface IBall
    {
        void SetSize(Vector3 size);

        void SetSpeed(float speed);

        void SetPosition(ITile tile);

        void SetDirection(Vector3 direction);

        bool IsOn<T>() where T : class;
    }
}