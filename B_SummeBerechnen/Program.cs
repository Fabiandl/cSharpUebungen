using System;

namespace SummeBerechnen
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            sumLeftToRight();
            sumRightToLeft();
            sumTeilSummen();
        }

        private static void sumLeftToRight()
        {
            bool minus = false;
            decimal summe = 0;
            for (int i = 1; i <= 10000; i++)
            {
                if (minus)
                {
                    summe -= (1 / i);
                }
                else
                {
                    summe += (1 / i);
                }

                minus = !minus;
            }

            Console.WriteLine(summe);
        }
        
        private static void sumRightToLeft()
        {
            bool minus = true;
            decimal summe = 0;
            for (int i = 10000; i >= 1; i--)
            {
                if (minus)
                {
                    summe = (-1 / i) + summe;
                }
                else
                {
                    summe = (1 / i) + summe;
                }

                minus = !minus;
            }

            Console.WriteLine(summe);
        }
        
        private static void sumTeilSummen()
        {
            bool minus = false;
            decimal postiveSum = 0;
            decimal negativeSum = 0;
            for (int i = 1; i <= 10000; i++)
            {
                if (minus)
                {
                    negativeSum -= (1 / i);
                }
                else
                {
                    postiveSum += (1 / i);
                }

                minus = !minus;
            }

            decimal summe = postiveSum + negativeSum;
            Console.WriteLine(summe);
        }
    }
}