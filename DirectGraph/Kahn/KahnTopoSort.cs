using System.Collections.Generic;

namespace DirectGraph.Kahn
{
    public class KahnTopoSort
    {
        public IList<int> sorted;

        public KahnTopoSort(Digraph digraph)
        {
            sorted = new List<int>();
            int[] inDegree = new int[digraph.NodeCount];
            // Traverse adjacency lists to fill indegrees of vertices. This step takes O(V+E) time  
            for (int v = 0; v < digraph.NodeCount; v++)
            {
                foreach (int w in digraph.Adjacent(v))
                {
                    inDegree[w] += 1;
                }
            }

            Sort(digraph, inDegree);
        }

        public void Sort(Digraph digraph, int[] inDegree)
        {
            // Create a queue and enqueue all vertices with indegree 0
            Queue<int> ready = new Queue<int>();
            for (int v = 0; v < digraph.NodeCount; v++)
            {
                if (inDegree[v] == 0)
                {
                    ready.Enqueue(v);
                }
            }
            // Initialize count of visited vertices
            int cnt = 0;
            // Extract front of queue(or perform dequeue) and add it to topological order
            while (ready.Count > 0)
            {
                int u = ready.Dequeue();
                sorted.Add(u);
                // Iterate through all its neighbouring nodes
                // of dequeued node u and decrease their in-degree by 1
                foreach (int adj in digraph.Adjacent(u))
                {
                    if (--inDegree[adj] == 0)
                    {
                        ready.Enqueue(adj);
                    }
                }

                cnt = +1;
            }
        }
    }
}
