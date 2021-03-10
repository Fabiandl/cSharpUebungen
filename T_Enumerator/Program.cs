using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace T_Enumerator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Reverse:");
            foreach (var x in MyEnumReverseString("Hallo"))
            {
                Console.Write(x);
            }
            Console.WriteLine();
            
            Console.WriteLine("Prims:");
            foreach (var y in MyEnumPrimzahlen(100))
            {
                Console.Write(y + ", ");
            }
            Console.WriteLine();
        }

        private static IEnumerable<int> MyEnumPrimzahlen(int border)
        {
            int c =1;
            while (c++ < border)
            {
                bool isprim = true;
                for (int j = 2; j*j <= border; j++)
                {
                    if (c % j == 0 && c != j)
                    {
                        isprim = false;
                    }
                }

                if (isprim)
                {
                    yield return c;
                }
            }
        }

        private static IEnumerable<string> MyEnumReverseString(string str)
        {
            int c = str.Length;
            while (c-- > 0)
            {
                yield return "c=" +str.ToCharArray()[c] + " ";
            }
        }
    }
}