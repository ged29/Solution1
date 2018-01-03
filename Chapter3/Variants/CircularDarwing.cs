using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3.Variants
{
    public class CircularDarwing : IDarwing
    {
        private List<Circle> shapes = new List<Circle>();
        // covariant Circle -> IShape
        public IEnumerable<IShape> Shapes
        {
            get { return shapes; }
        }
    }
}
