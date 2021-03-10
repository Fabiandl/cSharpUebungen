using System;
using System.Xml;

namespace S_NewtonLabda
{
    internal class Program
    {
        internal delegate double F(double d);

        public static void Main(string[] args)
        {
            double a = 2;
            F f = x => (1 - a / Math.Pow(x, 2));
            F f1 = x => 2 * a / Math.Pow(x, 3);

            double x0 = Newton(1, f, f1);

            Console.WriteLine($"NS bei {x0}");
        }

        public static double Newton(double x0, F f, F f1)
        {
            double x1 = f(x0);
            int n = 0;
            while (n < 100000 && Math.Abs(x1) > 1e-10)
            {
                x0 = x0 - (f(x0) / f1(x1));
                n++;
            }

            return x0;
        }
    }
}