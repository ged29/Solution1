using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DirectGraph
{
    public class Digraph
    {
        public int NodeCount { get; private set; }
        public int EdgeCount { get; private set; }
        private List<IList<int>> adjList;

        public Digraph(int nodeCount = 0)
        {
            if (nodeCount > 0)
            {
                adjList = new List<IList<int>>(Enumerable.Range(0, nodeCount).Select(x => new List<int>()));
                NodeCount = nodeCount;
            }
            else
            {
                adjList = new List<IList<int>>();
            }
        }

        public Digraph(string fileName) : this()
        {
            string absFileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "GraphFiles", fileName);

            NodeCount = int.Parse(File.ReadLines(absFileName).First());
            adjList.AddRange(Enumerable.Range(0, NodeCount).Select(x => new List<int>()));

            foreach (var line in File.ReadLines(absFileName).Skip(2))
            {
                int[] values = Array.ConvertAll(line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), val => int.Parse(val));
                int v = values[0];

                for (int inx = 1; inx < values.Length; inx++)
                {
                    AddEdge(v, values[inx]);
                }
            }
        }

        public void AddEdge(int v, int w) // the edge is v -> w 
        {
            adjList[v].Add(w);
            EdgeCount += 1;
        }

        public IList<int> Adjacent(int v)
        {
            return adjList[v];
        }

        public Digraph Reverse()
        {
            Digraph reversed = new Digraph(NodeCount);

            for (int v = 0; v < NodeCount; v++)
            {
                foreach (int w in Adjacent(v))
                {
                    reversed.AddEdge(w, v);
                }
            }

            return reversed;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int v = 0; v < NodeCount; v++)
            {
                sb.AppendFormat("{0} : [ {1} ]\n", v, String.Join(",", Adjacent(v)));
            }

            return sb.ToString();
        }
    }
}
