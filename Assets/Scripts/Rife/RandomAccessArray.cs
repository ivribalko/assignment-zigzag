using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ZigZag.Rife
{
    public class RandomAccessArray<T> : IEnumerable<T>
    {
        private readonly int count;
        private readonly IList<T> list;
        private readonly Random random = new Random();

        public RandomAccessArray(IReadOnlyList<T> list)
        {
            if (list.Count == 0)
            {
                throw new ArgumentException(nameof(list));
            }

            this.list = list.ToList();
            this.count = this.list.Count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Shuffle().GetEnumerator();
        }

        public T Next()
        {
            return this.list[this.random.Next(this.count)];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private IList<T> Shuffle()
        {
            var count = this.count;

            while (count > 1)
            {
                var k = this.random.Next(count);

                count -= 1;

                T value = list[k];
                list[k] = list[count];
                list[count] = value;
            }

            return this.list;
        }
    }
}