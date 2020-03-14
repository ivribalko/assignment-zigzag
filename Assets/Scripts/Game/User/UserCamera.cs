using UnityEngine;
using UnityEngine.Assertions;

namespace ZigZag.Game.User
{
    internal class UserCamera : MonoBehaviour, ICamera
    {
        [SerializeField] new Camera camera;

        public Bounds GetBounds()
        {
            Assert.IsTrue(this.camera.orthographic);

            var cameraHeight = camera.orthographicSize * 2;

            var position = camera.transform.localPosition;

            var center = new Vector3(position.x, position.y, position.z + camera.farClipPlane / 2);

            var size = new Vector3(
                cameraHeight * camera.aspect,
                cameraHeight,
                camera.farClipPlane);

            return new Bounds(center, size);
        }
    }
}