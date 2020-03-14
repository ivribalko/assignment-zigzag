using UnityEngine;

namespace ZigZag.Game.Ball
{
    public class Main : MonoBehaviour, IBall
    {
        private float speed;
        private Vector3 direction;

        public Vector3 Position
        {
            get => this.transform.localPosition;
            set => this.transform.localPosition = value;
        }

        private void Update()
        {
            this.transform.localPosition += Time.deltaTime * direction * speed;
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