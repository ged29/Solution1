using DirectGraph.FormCodeProject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectGraph.NetworkSort
{
    public class NetworkSort
    {
        public List<List<Item>> levels = new List<List<Item>>();
        private IList<List<int>> adjsMap;

        public NetworkSort(Item[] source)
        {
            int nodeCount = source.Length;
            int[] inDegree = new int[nodeCount];

            for (int v = 0; v < source.Length; v++)
            {
                inDegree[v] = source[v].Dependencies.Length;
            }

            Sort(source, inDegree);
        }

        private void Sort(Item[] source, int[] inDegree)
        {
            int nodeCount = source.Length;
            int currentLevel = 0;
            int processNodeCount = 0;

            while (processNodeCount != nodeCount)
            {
                levels.Add(new List<Item>());

                for (int v = 0; v < nodeCount; v++)
                {
                    if (inDegree[v] == 0)
                    {
                        Item item = source[v];
                        item.Level = currentLevel;
                        levels[currentLevel].Add(item);
                        processNodeCount++;


                    }
                }

                currentLevel += 1;
            }
        }

        public static void Test()
        {
            var a = new Item("A");
            var c = new Item("C");
            var f = new Item("F");
            var h = new Item("H");
            var d = new Item("D", a);
            var g = new Item("G", f, h);
            var e = new Item("E", d, g);
            var b = new Item("B", c, e);

            //var unsorted = new[] { a, b, c, d, e, f, g, h };
            var unsorted = new[] { a, c, f, h, d, g, e, b }; // to fit to topSort.txt file content
            var topSort = new NetworkSort(unsorted);

        }
    }
}
