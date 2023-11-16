using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math_lab3_new
{
    public static class Lagrange
    {
        public static MyPoint[] Interpolate(MyPoint[] points, int count)
        {
            int inputPointCount = points.Length;
            double distances = points.Last().X - points.First().X;
            double step = distances / count;

            double[] evenDistances = new double[count+1];

            evenDistances[0] = points.First().X;

            for (int i = 1; i <= count; i++)
            {
                evenDistances[i] = step * i;
            }


            var result = new MyPoint[count+1];

            for (int i = 0; i < evenDistances.Length; i++)
            {
                if (evenDistances[i] > points.Last().X)
                    continue;
                result[i] = new MyPoint(evenDistances[i], getF(points, evenDistances[i]));
            }

            return result;
        }

        private static double getF(MyPoint[] points, double x)
        {
            double result = 0;

            for (int i = 0; i < points.Length; i++)
            {
                var point = points[i];
                double temp = 1;

                for (int j = 0; j < points.Length; j++)
                {
                    if (i == j)
                        continue;

                    temp *= (x - points[j].X);
                    temp /= (point.X - points[j].X);
                }

                temp *= point.Y;

                result += temp;
            }

            return result;
        }
    }
}
