using UnityEngine;
using ZigZag.Game.Menu;

namespace ZigZag.Game.Gain
{
    internal class Main : MonoBehaviour, IView
    {
        public void Show()
        {
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }
    }
}