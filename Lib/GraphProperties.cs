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

    }
}
