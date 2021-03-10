using System;
using System.Collections.Generic;

namespace Fibo5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int n = 15;
            
            int f0 = 0;
            int f1 = 1;

            List<int> fibos = new List<int>();
            fibos.Add(f0);
            fibos.Add(f1);
            for (int i = 2; i <= n; i++)
            {
                fibos.Add(fibos[i-2] + fibos[i-1]);
            }
            Console.WriteLine(String.Join(",",fibos));
        }
    }
}