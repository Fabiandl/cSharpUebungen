using System;
using System.Collections.Generic;

namespace Primzahlen
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Primzahl berechen");
            Console.WriteLine("Bis welches n?");
            int n = int.Parse(Console.ReadLine());

            int c = 0;
            List<int> prims = new List<int>();
            int i = 1; 
            bool Prim = true;
            while (i <= n){ 
                for (int j = 2; j < i-1; j++){
                    if (i%j == 0){
                        Prim = false;
                    }
                }
        
                if (Prim)
                {
                    prims.Add(i);
                }else{
                    Prim = true;
          
                }
                i++;
        
            }
            Console.WriteLine("Die Prims sind:");
            ausgabe(prims);
        }

        private static void ausgabe(List<int> prims)
        {
            foreach (var VARIABLE in prims)
            {
                       Console.Write(VARIABLE + ", ");
            }
        }
    }
}