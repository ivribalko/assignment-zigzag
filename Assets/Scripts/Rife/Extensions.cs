using UnityEngine;

namespace ZigZag.Rife
{
    public static class Extensions
    {
        public static void PositionAt(this Transform target, Bounds bounds, Vector3 direction)
        {
            var diff = (bounds.size + target.localScale) / 2;

            diff.Scale(direction);

            target.localPosition = bounds.center + diff;
        }
    }
}