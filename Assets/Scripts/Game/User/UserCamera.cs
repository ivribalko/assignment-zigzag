using UnityEngine;
using Zenject;

namespace ZigZag.Game.User
{
    internal class UserCamera : MonoBehaviour, ICamera
    {
        private Plane[] planes;

        [SerializeField] new Camera camera;

        [Inject]
        private void Inject()
        {
            this.planes = GeometryUtility.CalculateFrustumPlanes(this.camera);
        }

        public bool Touches(Bounds bounds)
        {
            foreach (var plane in this.planes)
            {
                if (plane.GetDistanceToPoint(bounds.min) > 0 ||
                    plane.GetDistanceToPoint(bounds.max) > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Contains(Bounds bounds)
        {
            foreach (var plane in this.planes)
            {
                if (plane.GetDistanceToPoint(bounds.min) < 0 &&
                    plane.GetDistanceToPoint(bounds.max) < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}