using System;
using System.Linq;
using Investigate;
using Chapter2;
using Chapter3;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var cntEnumerable = new CountingEnumerable();

            foreach (var n in cntEnumerable)
            {
                Console.WriteLine(n);
            }
        }
    }
}
