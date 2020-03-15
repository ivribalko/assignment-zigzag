using System;
using UnityEngine;
using Zenject;

namespace ZigZag.Game.Gain
{
    internal class Main : IGain, IDisposable
    {
        public event Action OnChanged;

        public int Current { get; private set; }

        public int AllTime { get; private set; }

        private readonly SignalBus signalBus;

        public Main(SignalBus signalBus)
        {
            this.signalBus = signalBus;

            this.AllTime = PlayerPrefs.GetInt(nameof(this.AllTime));

            this.signalBus.Subscribe<SignalPick>(this.Increment);
        }

        public void ResetCurrent()
        {
            this.Current = 0;
        }

        public void Dispose()
        {
            this.signalBus.Unsubscribe<SignalPick>(this.Increment);
        }

        private void Increment()
        {
            this.Current += 1;
            this.AllTime = Mathf.Max(this.AllTime, this.Current);

            PlayerPrefs.SetInt(nameof(this.AllTime), this.AllTime);
            PlayerPrefs.Save();

            this.OnChanged?.Invoke();
        }
    }
}