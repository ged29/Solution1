using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Cycle
    {
        private bool[] visited;
        public bool HasCycle { get; private set; }

        public Cycle(Graph g)
        {
            HasCycle = false;

            visited = new bool[g.V];
            for (int s = 0; s < g.V; s++)
            {
                if (!visited[s])
                {
                    Dfs(g, s, s);
                }
            }
        }

        private void Dfs(Graph g, int v, int u)
        {
            visited[v] = true;

            foreach (int w in g.Adj(v))
            {
                if (!visited[w])
                {
                    Dfs(g, w, v);
                }
                else if (w != u)
                {
                    HasCycle = true;
                    return;
                }
            }
        }       

        public static void Test(Graph g)
        {
            Console.WriteLine("The Graph is " + (new Cycle(g).HasCycle ? "cycled" : "unCycled"));
        }
    }
}
