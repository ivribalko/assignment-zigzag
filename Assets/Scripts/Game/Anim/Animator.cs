using System;
using System.Collections;
using UnityEngine;

namespace ZigZag.Game.Anim
{
    internal class Animator : MonoBehaviour, IAnimator
    {
        const float DisappearIn = 2f;

        private Vector3 Acceleration => Vector3.down;

        public IDisposable Disappear(Component component)
        {
            var token = new Token();

            StartCoroutine(DisappearCoroutine(token, component.transform));

            return token;
        }

        // this is frame-dependent and doesn't set safely the value in the end
        // NB: this has to add to current local pos as tiles change it all the time
        private IEnumerator DisappearCoroutine(Token token, Transform transform)
        {
            var remaining = DisappearIn;

            while (!token.Disposed && remaining > 0)
            {
                remaining -= Time.deltaTime;

                var progress = (DisappearIn - remaining) / DisappearIn;

                transform.localPosition += this.Acceleration * progress;

                yield return null;
            }
        }
    }
}