using UnityEngine;

namespace ZigZag.Game.Path
{
    internal class Tile : MonoBehaviour, ITile
    {
        public Bounds Bounds =>
            throw new System.NotImplementedException();

        public Vector3 Size
        {
            get =>
                throw new System.NotImplementedException();
            set =>
                throw new System.NotImplementedException();
        }
        public Vector3 Position
        {
            get =>
                throw new System.NotImplementedException();
            set =>
                throw new System.NotImplementedException();
        }
    }
}