using System;

namespace potenz3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Potenz berechen b^n");
            Console.WriteLine("Was ist das b?");
            decimal b = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Was ist das n?");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Ergebnis:");
            Console.WriteLine(pot(b, n));
        }

        private static decimal pot(decimal b, int i)
        {
            decimal res = 1;
            for (int j = 1; j <= i; j++)
            {
                res = res * b;
            }

            if (i == 0)
            {
                return 1;
            }
            return res;
        }
    }
}