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
            this.transform.localPosition = Time.deltaTime * direction * speed;
        }

        public void SetDirection(Vector3 direction)
        {
            this.direction = direction;
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }
    }
}