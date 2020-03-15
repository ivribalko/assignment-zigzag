using UnityEngine;
using Zenject;

namespace ZigZag.Game.User
{
    public class UserCamera : MonoBehaviour, ICamera
    {
        [SerializeField] new Camera camera;

        private Plane[] planes;

        [Inject]
        private void Inject()
        {
            this.planes = GeometryUtility.CalculateFrustumPlanes(this.camera);
        }

        public bool Touches(Bounds bounds)
        {
            return GeometryUtility.TestPlanesAABB(this.planes, bounds);
        }
    }
}