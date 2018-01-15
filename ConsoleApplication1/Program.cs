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
using DirectGraph;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //var mediumGPath = Path.Combine(basePath, "GraphFiles", "mediumG.txt");
            //var tinyGPath = Path.Combine(basePath, "GraphFiles", "tinyG.txt");
            //var unCycledGPath = Path.Combine(basePath, "GraphFiles", "unCycledG.txt");

            Stopwatch sw = new Stopwatch(); 

            Digraph digraph = new Digraph("tinyDAG.txt");
            sw.Reset();
            sw.Start();
            DepthFirstOrder dfo = new DepthFirstOrder(digraph);
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);

            //Console.WriteLine("PreOrder: " + String.Join(",", dfo.PreOrder));
            //Console.WriteLine("PostOrder: " + String.Join(",", dfo.PostOrder));
            Console.WriteLine("ReversePostOrder: " + String.Join(",", dfo.ReversePostOrder));

            //DirectGraph.FormCodeProject.TestClient.Test();          
            //DirectGraph.FromRosettacode.TestClient.Test();

        }
    }
}
