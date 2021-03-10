using System;

namespace R_Lambda
{
    internal class Program
    {
        delegate double F(double d1);

        static Func<F,double, double> eval = (f,d) => f(d);

        delegate double F2(double d1, double d2, double d3);

        //Public
        private static Func<double, double, double, double> f21 = (a, b, c) => (a + b + c);

        delegate bool F3(int x, double a, double b);

        public static void Main(string[] args)
        {
            Console.WriteLine(eval(x => x * x,3));

            //Private Anonym
            F2 f2= (a, b, c) => (a + b + c);

            Console.WriteLine(f2(1,2,3));

            F3 f3 = (x, a, b) => a <= x && b >= x;

            Console.WriteLine(f3(2,1,4));
            Console.WriteLine(f3(1,2,3));
        }
    }
}