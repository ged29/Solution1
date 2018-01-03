using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3.Variants
{
    public class RectabgularDrawing : IDarwing
    {
        private List<Rectangle> shapes = new List<Rectangle>();

        public IEnumerable<IShape> Shapes
        {
            get { return shapes; }
        }
    }
}
