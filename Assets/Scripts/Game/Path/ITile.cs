using UnityEngine;
using ZigZag.Game.Anim;

namespace ZigZag.Game.Path
{
    public interface ITile : IHide
    {
        Bounds Bounds { get; }
        Vector3 Scale { get; }
        Vector3 Position { get; }

        void SetChild(Transform transform);
    }
}