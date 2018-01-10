namespace DirectGraph.FormCodeProject
{
    public class TestClient
    {
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

            var unsorted = new[] { a, b, c, d, e, f, g, h };
            var sorted = new TopologicalSort<Item>(unsorted);
        }
    }
}
