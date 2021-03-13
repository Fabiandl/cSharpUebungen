using System;

namespace Q_DelegateFeld
{
    internal class Program
    {

        delegate double Funktion(double d);

        public static void Main(string[] args)
        {
            Funktion[] funcs = {Math.Sin, Math.Cos, Math.Tan};

            for (double i = 0; i <= 2*Math.PI; i+=0.1)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("SIN");
                    }
                    else if(j == 1)
                    {
                        Console.Write("COS");
                    }
                    else
                    {
                        Console.Write("TAN");
                    }

                    Funktion f = funcs[j];
                    Console.Write($"({i}): {f(i),8} |");
                }

                Console .WriteLine();
            }
        }
    }
}