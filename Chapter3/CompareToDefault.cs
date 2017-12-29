using System;

namespace Chapter3
{
    public class CompareToDefault
    {
        static int Compare<T>(T value) where T : IComparable<T>
        {
            return value.CompareTo(default(T));
        }

        public static void Main()
        {
            Console.WriteLine(Compare("x"));
            Console.WriteLine(Compare(10));
            Console.WriteLine(Compare(0));
            Console.WriteLine(Compare(-10));
            Console.WriteLine(Compare(DateTime.MinValue));
        }
    }
}
