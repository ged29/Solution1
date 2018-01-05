using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public class DfsPaths
    {
        public bool[] Marked { get; private set; }
        public int[] EdgeTo { get; private set; }
        private readonly int initVertex;

        public DfsPaths(Graph g, int s)
        {
            initVertex = s;
            Marked = new bool[g.V];
            EdgeTo = Enumerable.Range(0, g.V).Select(item => -1).ToArray();
            Dfs(g, s);
        }

        private void Dfs(Graph g, int v)
        {
            Marked[v] = true;
            var adjs = g.Adj(v).ToArray();

            foreach (int w in g.Adj(v))
            {
                if (!Marked[w])
                {
                    EdgeTo[w] = v;
                    Dfs(g, w);
                }
            }
        }

        public bool HasPathTo(int v)
        {
            return Marked[v];
        }

        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v)) return Enumerable.Empty<int>();

            Stack<int> result = new Stack<int>();
            for (int x = v; x != initVertex; x = EdgeTo[x])
            {
                result.Push(x);
            }
            result.Push(initVertex);
            return result;
        }
    }
}
