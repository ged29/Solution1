using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class BfsPaths
    {
        private bool[] marked;
        public Dictionary<int, int> edgeTo;
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

        public int[] PathTo(int v)
        {
            if (!HasPathTo(v)) return new int[0];

            Stack<int> result = new Stack<int>();
            for (int x = v; x != initVertex; x = edgeTo[x])
            {
                result.Push(x);
            }

            result.Push(initVertex);
            return result.ToArray();
        }

        public int DistTo(int v)
        {
            int pathLen = PathTo(v).Length;
            return pathLen == 0 ? 0 : pathLen - 1;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var kvp in edgeTo)
            {
                sb.AppendFormat(" {0}-{1} ", kvp.Key, kvp.Value);
            }

            return sb.ToString();
        }
    }
}
