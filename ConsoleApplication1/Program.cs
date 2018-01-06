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
            var mediumGPath = Path.Combine(basePath, "GraphFiles", "mediumG.txt");
            var tinyGPath = Path.Combine(basePath, "GraphFiles", "tinyG.txt");
            var unCycledGPath = Path.Combine(basePath, "GraphFiles", "unCycledG.txt");

            Graph graph = Graph.CreateFromFile(tinyGPath);
            GraphProperties graphProps = new GraphProperties(graph);

            Console.WriteLine("eccentricity:" + graphProps.Eccentricity(3));
            Console.WriteLine("diameter:" + graphProps.Diameter());
            Console.WriteLine("radius:" + graphProps.Radius());
            Console.WriteLine("centerVertexIndex:" + graphProps.CenterVertexIndex());
            graphProps.Girth();
        }
    }
}
