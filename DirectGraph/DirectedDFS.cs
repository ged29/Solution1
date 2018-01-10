using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectGraph
{
    public class DirectedDFS
    {
        bool[] visited;

        public DirectedDFS(Digraph digraph, int source)
        {
            visited = new bool[digraph.NodeCount];
            Dfs(digraph, source);
        }

        public DirectedDFS(Digraph digraph, int[] sources)
        {
            visited = new bool[digraph.NodeCount];
            Array.ForEach(sources, (nodeId) =>
            {
                if (!visited[nodeId]) Dfs(digraph, nodeId);
            });
        }

        public bool IsVisited(int nodeId)
        {
            return visited[nodeId];
        }

        private void Dfs(Digraph digraph, int source)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(source);
            visited[source] = true;

            while (stack.Count != 0)
            {
                int v = stack.Pop();

                foreach (var w in digraph.Adjacent(v))
                {
                    if (!visited[w])
                    {
                        visited[w] = true;
                        stack.Push(w);
                    }
                }
            }
        }

        public static void Test(Digraph digraph, int[] sources)
        {

            DirectedDFS directedDFS = new DirectedDFS(digraph, sources);

            for (int s = 0; s < digraph.NodeCount; s++)
            {
                if (directedDFS.IsVisited(s))
                {
                    Console.Write(string.Format(" {0} ", s));
                }
            }

            Console.WriteLine();
        }
    }
}
