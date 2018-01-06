using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lib
{
    public class DegreesOfSeparation
    {
        public static void Main(string filename, char delimitor, string source, string sink)
        {
            SymbolGraph symbolGraph = new SymbolGraph(filename, delimitor);

            if (!symbolGraph.Contains(source))
            {
                Console.WriteLine(string.Format("Source {0} is out of DB", source));
            }

            if (!symbolGraph.Contains(sink))
            {
                Console.WriteLine(string.Format("Sink {0} is out of DB", sink));
            }

            int sourceIndex = symbolGraph.GetIndex(source);
            int sinkIndex = symbolGraph.GetIndex(sink);
            BfsPaths bfsTree = new BfsPaths(symbolGraph.Graph, sourceIndex);
            IEnumerable<string> paths = bfsTree.PathTo(sinkIndex).Select(index => symbolGraph.GetName(index));

            Console.WriteLine(string.Format("{0} -> {1}\n {2}", source, sink, String.Join("\n ", paths)));
        }

        public static void Test(string basePath)
        {
            //Main(Path.Combine(basePath, "GraphFiles", "routes.txt"), ' ', "JFK", "LAS");
            //Main(Path.Combine(basePath, "GraphFiles", "routes.txt"), ' ', "JFK", "DFW");
            //Main(Path.Combine(basePath, "GraphFiles", "movies.txt"), '/', "Bacon, Kevin", "Grant, Cary");
            Main(Path.Combine(basePath, "GraphFiles", "movies.txt"), '/', "Animal House (1978)", "Titanic (1997)");
        }
    }
}
