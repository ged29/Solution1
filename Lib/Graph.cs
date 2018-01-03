using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Graph
    {
        public int V { get; private set; }
        public int E { get; private set; }
        private IList<IList<int>> adj;

        public Graph(int v)
        {
            V = v;
            E = 0;
            adj = new List<IList<int>>(Enumerable.Range(0, v).Select(x => new List<int>()));
        }

        public static Graph CreateFromFile(string filePath)
        {
            string line;
            Graph graph;

            using (StreamReader reader = File.OpenText(filePath))
            {
                graph = new Graph(int.Parse(reader.ReadLine()));
                reader.ReadLine();

                while ((line = reader.ReadLine()) != null)
                {
                    var vtxs = Array.ConvertAll(line.Split(new[] { ' ' }), (x) => int.Parse(x));
                    graph.AddEdge(vtxs[0], vtxs[1]);
                }
            }

            return graph;
        }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
            E += 1;
        }

        public IEnumerable<int> Adj(int v)
        {
            return adj[v];
        }
    }
}
