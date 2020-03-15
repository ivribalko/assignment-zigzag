using System;

namespace ZigZag.Game.Gain
{
    public interface IGain
    {
        event Action<int> OnChanged;
    }
}