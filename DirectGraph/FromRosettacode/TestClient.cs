using System;
using System.Collections.Generic;
using System.Linq;

namespace DirectGraph.FromRosettacode
{
    public class Task
    {
        public string Name { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class TestClient
    {
        public static void Test()
        {
            List<Task> tasks = new List<Task>
            {
                new Task{Name="A", Message = "A - depends on B and C" },    //A
                new Task{Name="B", Message = "B - depends on none" },       //1
                new Task{Name="C", Message = "C - depends on D and E" },    //2
                new Task{Name="D", Message = "D - depends on none" },       //3
                new Task{Name="E", Message = "E - depends on F, G and H" }, //4
                new Task{Name="F", Message = "F - depends on I" },          //5
                new Task{Name="G", Message = "G - depends on none" },       //6
                new Task{Name="H", Message = "H - depends on none" },       //7
                new Task{Name="I", Message = "I - depends on none" },       //8
            };

            TopologicalSorter<Task> resolver = new TopologicalSorter<Task>();
            // now setting relations between them as described above
            resolver.Add(tasks[0], tasks[1], tasks[2]);
            //resolver.Add(tasks[1]); // no need for this since the task was already mentioned as a dependency
            resolver.Add(tasks[2], tasks[3], tasks[4]);
            //resolver.Add(tasks[3]); // no need for this since the task was already mentioned as a dependency
            resolver.Add(tasks[4], tasks[5], tasks[6], tasks[7]);
            resolver.Add(tasks[5], tasks[8]);
            //resolver.Add(tasks[6]); // no need for this since the task was already mentioned as a dependency
            //resolver.Add(tasks[7]); // no need for this since the task was already mentioned as a dependency
            var result = resolver.Sort();
            var sorted = result.Item1;
            var cycled = result.Item2;

            if (!cycled.Any())
            {
                foreach (var d in sorted) Console.WriteLine(d.Message);
            }
            else
            {
                Console.Write("Cycled dependencies detected: ");

                foreach (var d in cycled) Console.Write($"{d.Message[0]} ");

                Console.WriteLine();
            }

            Console.WriteLine("exiting...");
        }
    }
}
