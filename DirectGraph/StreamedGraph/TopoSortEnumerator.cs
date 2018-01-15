using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectGraph.StreamedGraph
{
    public class TopoSortEnumerator<TItem, TKey> : IEnumerator<TItem>
    {
        private readonly IEnumerator<TItem> source;
        private readonly Func<TItem, TKey> getKey;
        private readonly Func<TItem, IEnumerable<TKey>> getDependencies;
        private readonly HashSet<TKey> sortedItems;
        private readonly Queue<TItem> readyToOutput;
        private readonly WaitList<TItem, TKey> waitList = new WaitList<TItem, TKey>();

        public TItem Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        object IEnumerator.Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
