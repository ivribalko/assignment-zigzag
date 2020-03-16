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
            this.signalBus.Subscribe<SignalReset>(this.ResetCurrent);
        }

        public void Dispose()
        {
            this.signalBus.Unsubscribe<SignalPick>(this.Increment);
            this.signalBus.Unsubscribe<SignalReset>(this.ResetCurrent);
        }

        private void ResetCurrent()
        {
            this.Current = 0;
            this.OnChanged?.Invoke();
        }

        private void Increment()
        {
            if (this.Current < int.MaxValue)
            {
                this.Current += 1;

                this.AllTime = Mathf.Max(this.AllTime, this.Current);

                PlayerPrefs.SetInt(nameof(this.AllTime), this.AllTime);
                PlayerPrefs.Save();

                this.OnChanged?.Invoke();
            }
        }
    }
}