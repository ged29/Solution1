using System;

namespace Chapter3
{
    public static class ТуреИісЬРіе1ё<T>
    {
        public static string field;
        public static void PrintField()
        {
            Console.WriteLine(field + ":" + typeof(T).Name);
        }
    }

    public struct TypeWithFieldTest
    {
        public static void Main()
        {
            ТуреИісЬРіе1ё<int>.field = "For int";
            ТуреИісЬРіе1ё<string>.field = "For string";
            ТуреИісЬРіе1ё<DateTime>.field = "For DateTime";

            ТуреИісЬРіе1ё<int>.PrintField();
            ТуреИісЬРіе1ё<string>.PrintField();
            ТуреИісЬРіе1ё<DateTime>.PrintField();
        }
    }
}
