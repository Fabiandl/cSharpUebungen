using System;

namespace P_Lambda
{
    internal class Program
    {
        delegate int Funktion(int i, int j);

        private static Funktion addieren = (i, i1) => i + i1;

        private static Funktion multi = (i, i1) => i * i1;

        public static void Main(string[] args)
        {
            int z1 = 2;
            int z2 = 3;

            Funktion f = addieren;
            Console.WriteLine(f(z1,z2));
            f = multi;
            Console.WriteLine(f(z1,z2));
        }
    }
}