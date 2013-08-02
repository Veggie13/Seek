using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seek
{
    static class Seek
    {
        static double[] b = { 310.3, 100.9, 123, 296.8, 12.4, 10.6 };
        static double[] d = { 15.7, 6.9, 6.65, 13.8, 13.4, 10.6 };
        static double[] alt = { 0, 0, 0, 0, 0, 0 };
        static double srcAlt = 3.47;
        static double g = 0.00981;
        public static double f(params double[] x)
        {
            double[] Vi = { x[0], x[1], x[2], x[3], x[4], x[5] };
            double[] M = { x[6], x[7], x[8], x[9], x[10], x[11] };


            double Px = 0, Py = 0, Pz = 0;
            for (int i = 0; i < Vi.Length; i++)
            {
                double bR = Math.PI * b[i] / 180;
                double h = srcAlt - alt[i];
                double tanA = (Vi[i]*Vi[i] + Math.Sqrt(Math.Pow(Vi[i],4) + g * (2 * h * Vi[i]*Vi[i] - g * d[i]*d[i]))) / (g * d[i]);
                double A = Math.Atan(tanA);
                double Vz = Vi[i] * Math.Sin(A);
                double Vf = Vi[i] * Math.Cos(A);
                double Vx = Vf * Math.Cos(bR);
                double Vy = Vf * Math.Sin(bR);
                Px += M[i] * Vx;
                Py += M[i] * Vy;
                Pz += M[i] * Vz;
            }

            return Px * Px + Py * Py + Pz * Pz;
        }

        public static void Main()
        {
        }
    }
}
