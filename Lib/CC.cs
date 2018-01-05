using System;
using System.Collections.Generic;

namespace Lib
{
    /// <summary>
    /// Connected components
    /// </summary>
    public class CC
    {
        private bool[] marked;
        private int[] id;
        private int count;

        public CC(Graph g)
        {
            marked = new bool[g.V];
            id = new int[g.V];
            count = 1;

            for (int s = 0; s < g.V; s++)
            {
                if (!marked[s])
                {
                    Dfs(g, s);
                    count += 1;
                }
            }
        }

        private void Dfs(Graph g, int s)
        {
            Stack<int> stack = new Stack<int>();
            marked[s] = true;
            id[s] = count;
            stack.Push(s);

            while (stack.Count != 0)
            {
                int v = stack.Pop();

                foreach (int w in g.Adj(v))
                {
                    if (!marked[w])
                    {
                        marked[w] = true;
                        id[w] = count;
                        stack.Push(w);
                    }
                }
            }
        }

        public bool Connected(int v, int w)
        {
            return id[v] == id[w];
        }

        public int Id(int v)
        {
            return id[v];
        }

        public int Count()
        {
            return count - 1;
        }

        public IDictionary<int, IList<int>> GetComponents()
        {
            var result = new Dictionary<int, IList<int>>();

            if (Count() == 0)
            {
                return null;
            }

            for (int inx = 0; inx < id.Length; inx++)
            {
                int theId = id[inx];
                if (!result.ContainsKey(theId))
                {
                    result[theId] = new List<int>();
                }

                result[theId].Add(inx);
            }

            return result;
        }

        public static void Test(Graph g)
        {
            CC cc = new CC(g);

            Console.WriteLine("Connected components\n");

            foreach (KeyValuePair<int, IList<int>> comp in cc.GetComponents())
            {
                Console.WriteLine(string.Format("[{0}] : {1}\n", comp.Key, String.Join(",", comp.Value)));
            }
        }
    }
}
