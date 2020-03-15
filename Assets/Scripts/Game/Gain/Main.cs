using System;
using UnityEngine;

namespace ZigZag.Game.Gain
{
    internal class Main : IGain
    {
        public event Action OnChanged;

        public int Current { get; private set; }

        public int AllTime { get; private set; }

        private Main()
        {
            this.Current = PlayerPrefs.GetInt(nameof(this.Current));
            this.AllTime = PlayerPrefs.GetInt(nameof(this.AllTime));
        }

        private void Save(int count)
        {
            this.Current = count;
            this.AllTime = Mathf.Max(this.AllTime, this.Current);

            PlayerPrefs.SetInt(nameof(this.Current), this.Current);
            PlayerPrefs.SetInt(nameof(this.AllTime), this.AllTime);

            PlayerPrefs.Save();

            this.OnChanged?.Invoke();
        }
    }
}