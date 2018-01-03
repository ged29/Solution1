using System.Diagnostics;

namespace Lib
{
    public class DepthFirstSearch
    {
        public bool[] Marked { get; private set; }
        public int Count { get; private set; }

        public DepthFirstSearch(Graph g, int s)
        {
            Marked = new bool[g.V];
            Count = 0;            
            Dfs(g, s);
        }

        private void Dfs(Graph g, int v)
        {
            Marked[v] = true;
            Count += 1;

            Debug.WriteLine(v);

            foreach (int w in g.Adj(v))
            {
                if (!Marked[w])
                {
                    Dfs(g, w);
                }
            }
        }
    }
}
