using System;
using System.Collections.Generic;

namespace ZigZag.Rife
{
    public class CircularArray<T>
    {
        private readonly IList<T> list;

        private int current;

        public CircularArray(IList<T> list)
        {
            if (list.Count == 0)
            {
                throw new ArgumentException(nameof(list));
            }

            this.list = list;

            this.Current = list[current];
        }

        public T Current { get; private set; }

        public T Next()
        {
            this.current += 1;

            if (current > this.list.Count - 1)
            {
                this.current = 0;
            }

            this.Current = this.list[current];

            return this.Current;
        }
    }
}