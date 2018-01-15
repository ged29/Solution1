using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectGraph
{
    public class SymbolDigraph
    {
        private readonly IDictionary<string, int> st;
        private readonly string[] keys;
        public Digraph graph;

        public SymbolDigraph(string fileName, char delimiter)
        {
            st = new Dictionary<string, int>();
            foreach (string line in File.ReadAllLines(fileName))
            {
                line.Split(delimiter).ToList().ForEach(item =>
                {
                    if (!st.ContainsKey(item))
                    {
                        st[item] = st.Count;
                    }
                });
            }

            keys = new string[st.Count];
            foreach (var kvp in st)
            {
                keys[kvp.Value] = kvp.Key;
            }

            graph = new Digraph(st.Count);
            foreach (string line in File.ReadAllLines(fileName))
            {
                string[] values = line.Split(delimiter).ToArray();

                for (int inx = 1; inx < values.Length; inx++)
                {
                    graph.AddEdge(GetIndex(values[0]), GetIndex(values[inx]));
                }
            }
        }

        public int GetIndex(string key)
        {
            return st[key];
        }

        public string GetKey(int index)
        {
            return keys[index];
        }
    }
}
