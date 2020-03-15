using System;

namespace ZigZag.Game.Gain
{
    internal class Bind : IDisposable
    {
        private readonly View view;
        private readonly Main main;

        public Bind(View view, Main main)
        {
            this.view = view;
            this.main = main;

            this.main.OnChanged += this.Update;

            this.Update();
        }

        public void Dispose()
        {
            this.main.OnChanged -= this.Update;
        }

        private void Update()
        {
            this.view.Set(this.main.Current, this.main.AllTime);
        }
    }
}