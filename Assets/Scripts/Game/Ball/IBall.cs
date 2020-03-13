using System.Numerics;

namespace ZigZag.Game.Ball
{
    public interface IBall
    {
        Vector3 Position { get; }

        void SetSpeed(float speed);

        void SetDirection(Vector3 direction);
    }
}