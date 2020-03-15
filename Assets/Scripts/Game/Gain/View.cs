using UnityEngine;
using ZigZag.Game.Menu;

namespace ZigZag.Game.Gain
{
    internal class View : MonoBehaviour, IView
    {
        [SerializeField] private TextMesh text;

        public void Set(int count)
        {
            text.text = count.ToString();
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