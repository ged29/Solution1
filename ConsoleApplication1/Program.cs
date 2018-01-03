using System;
using System.Linq;
using Investigate;
using Chapter2;
using Chapter3;
using System.Collections.Generic;
using Chapter3.Variants;
using System.Drawing;
using Chapter5;
using Lib;
using System.Reflection;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var largeGPath = Path.Combine(basePath, "GraphFiles", "largeG.txt");
            var mediumGPath = Path.Combine(basePath, "GraphFiles", "mediumG.txt");
            var tinyGPath = Path.Combine(basePath, "GraphFiles", "tinyG.txt");

            Graph g = Graph.CreateFromFile(tinyGPath);
            int initVertex = 0;
            Paths gPaths = new Paths(g, initVertex);

            for (int v = 0; v < g.V; v++)
            {
                Console.Write(v + " to " + initVertex + ": ");
                foreach (int x in gPaths.PathTo(v))
                {
                    if (x == v)
                    {
                        Console.Write(x);
                    }
                    else
                    {
                        Console.Write(x + "-");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
