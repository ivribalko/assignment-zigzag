using UnityEngine;

namespace ZigZag.Game.Path
{
    public interface ITile
    {
        Bounds Bounds { get; }
        Vector3 Size { get; set; }
        Vector3 Position { get; set; }
    }
}