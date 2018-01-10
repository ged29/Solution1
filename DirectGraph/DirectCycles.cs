using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectGraph
{
    public class DirectCycles
    {
        bool[] visited;
        int[] edgeTo;
        bool[] onStack;
        IDictionary<int, int[]> cycledPaths;

        public DirectCycles(Digraph digraph)
        {
            int nodeCount = digraph.NodeCount;
            visited = new bool[nodeCount];
            cycledPaths = new Dictionary<int, int[]>();
            edgeTo = new int[nodeCount];
            onStack = new bool[nodeCount];

            for (int inx = 0; inx < nodeCount; inx++)
            {
                edgeTo[inx] = -1;
            }

            for (int s = 0; s < nodeCount; s++)
            {
                if (!visited[s])
                {
                    Dfs(digraph, s);
                }
            }
        }

        private void DfsRec(Digraph digraph, int v)
        {
            visited[v] = true;
            onStack[v] = true;

            foreach (int w in digraph.Adjacent(v))
            {
                if (!visited[w])
                {
                    edgeTo[w] = v;
                    DfsRec(digraph, w);
                }
                else if (onStack[w])
                {
                    Stack<int> stack = new Stack<int>();
                    for (int x = v; x != w && x != -1; x = edgeTo[x])
                    {
                        stack.Push(x);
                    }
                    stack.Push(w);
                    stack.Push(v);
                    cycledPaths[cycledPaths.Count] = stack.ToArray();
                }
                onStack[w] = false;
            }

        }

        private void Dfs(Digraph digraph, int s)
        {
            bool[] onPath = new bool[digraph.NodeCount];
            Stack<int> stack = new Stack<int>();
            stack.Push(s);
            visited[s] = true;
            onPath[s] = true;

            while (stack.Count != 0)
            {
                int v = stack.Pop();
                //onPath[v] = false;
                Console.WriteLine(v);

                foreach (int w in digraph.Adjacent(v))
                {
                    if (!visited[w])
                    {
                        edgeTo[w] = v;
                        onPath[w] = true;
                        visited[w] = true;
                        stack.Push(w);
                    }
                    else if (onPath[w]) // already went through
                    {
                        Stack<int> tmp = new Stack<int>();
                        for (int x = v; x != w && x != -1; x = edgeTo[x])
                        {
                            tmp.Push(x);
                        }
                        tmp.Push(w);
                        tmp.Push(v);
                        cycledPaths[cycledPaths.Count] = tmp.ToArray();
                    }
                }
            }
        }
    }
}
