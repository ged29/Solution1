using System.Collections;
using System.Collections.Generic;

namespace Chapter3
{
    public class CountingEnumerable : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new CountingEnumerator(10);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class CountingEnumerator : IEnumerator<int>
    {
        private int limit;

        public CountingEnumerator(int limit)
        {
            this.limit = limit;
            Reset();
        }

        public int Current { get; private set; }  // IEnumerator<int> implicity realization

        object IEnumerator.Current { get { return Current; } } // IEnumerator<int> explicity realization

        public bool MoveNext()
        {
            Current++;
            return Current < limit;
        }

        public void Reset()
        {
            Current = -1;
        }

        public void Dispose() { }
    }
}
