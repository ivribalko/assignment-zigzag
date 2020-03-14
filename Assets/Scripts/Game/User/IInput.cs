using System;

namespace ZigZag.Game.User
{
    public interface IInput
    {
        event Action OnTouch;
    }
}