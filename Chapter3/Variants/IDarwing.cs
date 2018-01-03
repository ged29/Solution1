using System.Collections.Generic;

namespace Chapter3.Variants
{
    public interface IDarwing
    {
        IEnumerable<IShape> Shapes { get; }
    }
}
