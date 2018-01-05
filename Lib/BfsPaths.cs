using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class BfsPaths
    {
        private bool[] marked;
        private IDictionary<int, int> edgeTo;
        private readonly int initVertex;

        public BfsPaths(Graph g, int s)
        {
            initVertex = s;
            marked = new bool[g.V];
            edgeTo = new Dictionary<int, int>();
            Bfs(g, s);
        }

        private void Bfs(Graph g, int s)
        {
            Queue<int> queue = new Queue<int>();
            marked[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                int v = queue.Dequeue();
                foreach (int w in g.Adj(v))
                {
                    if (!marked[w])
                    {
                        marked[w] = true;
                        edgeTo[w] = v;
                        queue.Enqueue(w);
                    }
                }
            }
        }

        public bool HasPathTo(int v)
        {
            return marked[v];
        }

        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v)) return Enumerable.Empty<int>();

            Stack<int> result = new Stack<int>();
            for (int x = v; x != initVertex; x = edgeTo[x])
            {
                result.Push(x);
            }

            result.Push(initVertex);
            return result;
        }
    }
}
