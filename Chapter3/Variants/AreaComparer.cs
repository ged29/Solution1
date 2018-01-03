using System.Collections.Generic;

namespace Chapter3.Variants
{
    public sealed class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape x, IShape y)
        {
            return x.Area.CompareTo(y.Area);
        }
    }
}
