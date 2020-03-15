using System;

namespace ZigZag.Game.Gain
{
    public interface IGain
    {
        event Action OnChanged;

        int Current { get; }

        int AllTime { get; }

        void ResetCurrent();
    }
}