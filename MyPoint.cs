using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math_lab3_new
{
    public class MyPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
        public MyPoint(double x, double y)
        {
            this.X = x; this.Y = y;
        }

        public override string ToString()
        {
            return string.Format("{0};{1}", this.X, this.Y);
        }
    }
}
