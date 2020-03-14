using UnityEngine;

namespace ZigZag.Game.User
{
    public interface ICamera
    {
        bool Touches(Bounds bounds);
        bool Envelopes(Bounds bounds);
    }
}