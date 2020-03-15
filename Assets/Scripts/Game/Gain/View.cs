using UnityEngine;
using ZigZag.Game.Menu;

namespace ZigZag.Game.Gain
{
    internal class View : MonoBehaviour, IView
    {
        [SerializeField] private TextMesh text;

        public void Set(int current, int allTime)
        {
            text.text = $"{current}/{allTime}";
        }

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