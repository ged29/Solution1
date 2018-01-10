using System;
using System.Collections.Generic;

namespace Lib
{
    public class GraphProperties
    {
        private int maxVertexIndex;
        private int minVertexIndex;
        private Dictionary<int, int> pathLens = new Dictionary<int, int>();
        private Graph graph;

        public GraphProperties(Graph graph)
        {
            this.graph = graph;

            BfsPaths bfsPaths = new BfsPaths(graph, 0);
            for (int v = 0; v < graph.V; v++)
            {
                pathLens.Add(v, bfsPaths.HasPathTo(v) ? bfsPaths.DistTo(v) : -1);
            }

            int max = int.MinValue;
            int min = int.MaxValue;

            foreach (var kvp in pathLens)
            {
                if (kvp.Value == -1) continue;

                if (kvp.Value > max)
                {
                    max = kvp.Value;
                    maxVertexIndex = kvp.Key;
                }

                if (kvp.Value < min)
                {
                    min = kvp.Value;
                    minVertexIndex = kvp.Key;
                }
            }

            if (max == int.MinValue)
            {
                maxVertexIndex = -1;
            }

            if (min == int.MaxValue)
            {
                minVertexIndex = -1;
            }
        }

        public int Eccentricity(int v)
        {
            return pathLens.ContainsKey(v) ? pathLens[v] : 0;
        }

        public int Diameter()
        {
            return maxVertexIndex == -1 ? -1 : pathLens[maxVertexIndex];
        }

        public int Radius()
        {
            return minVertexIndex == -1 ? -1 : pathLens[minVertexIndex];
        }

        public int CenterVertexIndex()
        {
            return minVertexIndex;
        }

        public void Girth()
        {
            Dictionary<int, Dictionary<int, int>> bfsPaths = new Dictionary<int, Dictionary<int, int>>();

            for (int inx = 0; inx < graph.V; inx++)
            {
                var bfsPath = new BfsPaths(graph, inx);
                Console.WriteLine(string.Format("{0}:{1}", inx, bfsPath));
                bfsPaths.Add(inx, bfsPath.edgeTo);
            }

            for (int v = 0; v < graph.V; v++)
            {
                IList<int> adjs = graph.Adj(v);
                int adjsCount = adjs.Count;
                if (adjsCount == 0 || adjsCount == 1) continue;  // in case of isolated node or node with one connection                
                // here we know that v has at least 2 node adjacent to it
                for (int inx = 0; inx < adjsCount; inx++)
                {
                    List<int> adjNodeIds = new List<int>(adjs); adjNodeIds.RemoveAt(inx);
                    FindCircle(adjs[inx], adjNodeIds, bfsPaths, v);
                }
            }
        }

        private void FindCircle(int fromNodeId, IList<int> adjNodeIds, Dictionary<int, Dictionary<int, int>> bfsPaths, int filterById)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(fromNodeId);

            bool[] inspected = new bool[graph.V];
            inspected[filterById] = true;
            inspected[fromNodeId] = true;

            IList<int> result = new List<int>();


            while (stack.Count != 0)
            {
                var fromItem = stack.Pop();
                result.Add(fromItem);

                foreach (var kvp in bfsPaths[fromItem])
                {
                    var toItem = kvp.Key;

                    if (kvp.Value == fromItem && !inspected[toItem]) // filter out the paths by fromItem value
                    {
                        if (adjNodeIds.Contains(kvp.Key))
                        {
                            return;
                        }
                        else
                        {
                            stack.Push(toItem);
                            inspected[toItem] = true;
                        }
                    }
                }



            }
        }
    }
}
