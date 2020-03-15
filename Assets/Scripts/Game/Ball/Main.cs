using System;
using UnityEngine;
using ZigZag.Game.Path;
using ZigZag.Rife;

namespace ZigZag.Game.Ball
{
    public class Main : MonoBehaviour, IBall
    {
        public event Action<Vector3> OnMoveUpdate;

        private float speed;
        private Vector3 direction;

        private void Update()
        {
            this.OnMoveUpdate?.Invoke(Time.deltaTime * direction * speed);
        }

        public void SetSize(Vector3 size)
        {
            this.transform.localScale = size;
        }

        public void SetPosition(ITile tile)
        {
            this.transform.PositionAt(tile.Bounds, Vector3.up);
        }

        public void SetDirection(Vector3 direction)
        {
            this.direction = direction;
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        public bool IsOn<T>() where T : class
        {
            if (Physics.Raycast(
                    origin: this.transform.localPosition,
                    direction: Vector3.down,
                    hitInfo: out RaycastHit hit,
                    maxDistance: this.transform.localScale.y))
            {
                return hit
                    .collider
                    .gameObject
                    .GetComponent<T>() != null;
            }

            return false;
        }
    }
}