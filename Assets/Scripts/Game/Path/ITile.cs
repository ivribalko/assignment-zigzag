using UnityEngine;

namespace ZigZag.Game.Path
{
    public interface ITile
    {
        Bounds Bounds { get; }
        Vector3 Scale { get; }
        Vector3 Position { get; set; }
    }
}