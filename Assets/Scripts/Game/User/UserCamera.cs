using UnityEngine;
using Zenject;

namespace ZigZag.Game.User
{
    public class UserCamera : MonoBehaviour, ICamera
    {
        [SerializeField] new Camera camera;

        private Plane[] planes;
        private Vector3[] vertices;

        [Inject]
        private void Inject()
        {
            this.planes = GeometryUtility.CalculateFrustumPlanes(this.camera);

            this.vertices = new Vector3[8];
        }

        public bool Envelopes(Bounds bounds)
        {
            this.vertices[0] = bounds.min;
            this.vertices[1] = bounds.max;
            this.vertices[2] = new Vector3(bounds.min.x, bounds.min.y, bounds.max.z);
            this.vertices[3] = new Vector3(bounds.min.x, bounds.max.y, bounds.min.z);
            this.vertices[4] = new Vector3(bounds.max.x, bounds.min.y, bounds.min.z);
            this.vertices[5] = new Vector3(bounds.min.x, bounds.max.y, bounds.max.z);
            this.vertices[6] = new Vector3(bounds.max.x, bounds.min.y, bounds.max.z);
            this.vertices[7] = new Vector3(bounds.max.x, bounds.max.y, bounds.min.z);

            foreach (var plane in this.planes)
            {
                foreach (var point in this.vertices)
                {
                    var viewport = this.camera.WorldToViewportPoint(point);

                    if (viewport.x < 0 || viewport.x > 1 ||
                        viewport.y < 0 || viewport.y > 1 ||
                        viewport.z < this.camera.nearClipPlane ||
                        viewport.z > this.camera.farClipPlane)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool Touches(Bounds bounds)
        {
            return GeometryUtility.TestPlanesAABB(this.planes, bounds);
        }
    }
}