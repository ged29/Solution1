using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        public IList<IList<int>> adj;
        public readonly string name;

        public Graph(int v, string name = null)
        {
            V = v;
            E = 0;
            adj = new List<IList<int>>(Enumerable.Range(0, v).Select(x => new List<int>()));
            this.name = name;
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

        public bool HasEdge(int v, int w)
        {
            return v <= V && w <= V && adj[v] != null && adj[v].Contains(w);
        }

        public IList<int> Adj(int v)
        {
            return adj[v];
        }

        public override string ToString()
        {
            string grapgName = name ?? "Unknow";
            Collection<string> pairs = new Collection<string>();
            Func<int, int, string> getPair = (from, to) => string.Format("{0}-{1}", from, to);

            for (int from = 0; from < V; from++)
            {
                for (int inx = 0; inx < adj[from].Count; inx++)
                {
                    int to = adj[from][inx];
                    if (!pairs.Contains(getPair(to, from)))
                    {
                        pairs.Add(getPair(from, to));
                    }
                }
            }



            return string.Format("Graph:{0}\n{1}", grapgName, String.Join("\n", pairs));
        }
    }
}
