using UnityEngine;

namespace ZigZag.Game.Ball
{
    public interface IBall
    {
        Vector3 Position { get; set; }

        void SetSpeed(float speed);

        void SetDirection(Vector3 direction);
    }
}