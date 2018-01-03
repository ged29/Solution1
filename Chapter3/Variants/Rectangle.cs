using System.Drawing;

namespace Chapter3.Variants
{
    public class Rectangle : IShape
    {
        private readonly Point topLeft;
        private readonly Size size;

        public Rectangle(Point topLeft, Size size)
        {
            this.topLeft = topLeft;
            this.size = size;
        }

        public double Area
        {
            get { return size.Height * size.Width; }
        }
    }
}
