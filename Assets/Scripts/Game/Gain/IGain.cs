using System;

namespace ZigZag.Game.Gain
{
    internal interface IGain
    {
        event Action OnChanged;

        int Current { get; }

        int AllTime { get; }
    }
}