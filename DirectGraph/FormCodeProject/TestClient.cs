using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DirectGraph.FormCodeProject
{
    public class TestClient
    {
        public static void TestDirectInputTopologicalSort1()
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
            var topSort = new TopologicalSort<Item>(unsorted);
            Console.WriteLine(String.Join(",", topSort.sorted.Select(x => x.Name)));
            Console.WriteLine();
        }

        public static void TestDirectInputTopologicalSort2()
        {
            var a = new Item("A");
            var c = new Item("C");
            var f = new Item("F");
            var h = new Item("H");
            //d - a
            var d = new Item("D", new Item("A"));
            //g - [f, h]
            var g = new Item("G", new Item("F"), new Item("H"));
            //e - [d[a]], [g[f,h]]
            var e = new Item("E", new Item("D", new Item("A")), new Item("G", new Item("F"), new Item("H")));
            //b -[c, e[d[a]], g[f,h]]
            var b = new Item("B", new Item("C"), new Item("E", new Item("D", new Item("A")), new Item("G", new Item("F"), new Item("H"))));

            var unsorted = new[] { a, c, f, h, d, g, e, b }; // to fit to topSort.txt file content
            var topSort = new TopologicalSort<Item>(unsorted, new ItemEqualityComparer());
            Console.WriteLine(String.Join(",", topSort.sorted.Select(x => x.Name)));
            Console.WriteLine();
        }

        public static void TestFileInputTopologicalSort()
        {
            string absFileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "GraphFiles", "topSort.txt");
            SymbolDigraph symbolDigraph = new SymbolDigraph(absFileName, ' ');
            DepthFirstOrder dfsOrder = new DepthFirstOrder(symbolDigraph.graph);

            string preOrderList = String.Join(",", Array.ConvertAll(dfsOrder.PreOrder, x => symbolDigraph.GetKey(x)));
            string postOrderList = String.Join(",", Array.ConvertAll(dfsOrder.PostOrder, x => symbolDigraph.GetKey(x)));
            string reversePostOrderList = String.Join(",", Array.ConvertAll(dfsOrder.ReversePostOrder, x => symbolDigraph.GetKey(x)));

            Console.WriteLine(string.Format("PreOrder:{0}", preOrderList));
            Console.WriteLine(string.Format("PostOrder:{0}", postOrderList));
            Console.WriteLine(string.Format("ReversePostOrder:{0}", reversePostOrderList));
        }

        public static void TestTopologicalGrouping()
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
            var topGrouping = new TopologicalGrouping<Item>(unsorted);
            Console.WriteLine(String.Join(" / ", topGrouping.sorted.Select(level => String.Join(",", level.Select(l => l.Name)))));
            Console.WriteLine();
        }
    }
}
