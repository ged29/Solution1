using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lib
{
    public class SymbolGraph
    {
        private readonly IDictionary<string, int> st;
        private readonly string[] keys;
        public Graph Graph { get; private set; }

        public SymbolGraph(string filename, char delimiter)
        {
            string line;
            st = new Dictionary<string, int>();

            using (StreamReader reader = File.OpenText(filename))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    line.Split(delimiter).ToList().ForEach(key =>
                    {
                        if (!st.ContainsKey(key))
                        {
                            st[key] = st.Count;
                        }
                    });
                }
            }


            keys = new string[st.Count];
            foreach (var kvp in st)
            {
                keys[kvp.Value] = kvp.Key;
            }

            Graph = new Graph(st.Count);
            using (StreamReader reader = File.OpenText(filename))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    var list = line.Split(delimiter);
                    int v = GetIndex(list[0]);
                    for (int inx = 1; inx < list.Length; inx++)
                    {
                        Graph.AddEdge(v, GetIndex(list[inx]));
                    }
                }
            }
        }

        public bool Contains(string key)
        {
            return st.ContainsKey(key);
        }

        public int GetIndex(string key)
        {
            return st[key];
        }

        public string GetName(int index)
        {
            return keys[index];
        }

        public IEnumerable<string> GetAdjacent(string key)
        {
            return Graph.Adj(GetIndex(key)).Select(item => keys[item]);
        }

        public static void Test(string filename, char delimiter, string query = null)
        {
            var sg = new SymbolGraph(filename, delimiter);
            Action<string> show = (key) => Console.WriteLine(string.Format("{0} : [{1}]\n", key, String.Join(",", sg.GetAdjacent(key))));

            if (query != null)
            {
                show(query);
            }
            else
            {
                Array.ForEach(sg.keys, show);
            }
        }
    }
}
