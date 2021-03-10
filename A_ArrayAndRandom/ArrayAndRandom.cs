using System;

namespace UebungsBearbeitung
{
    internal class ArrayAndRandom
    {
        public static void Main(string[] args)
        {
            int[] liste = new int[10];
            var rand = new Random();
            for (int i = 0; i < liste.Length; i++)
            {
                liste[i] = rand.Next(2, 10);
            }

            ausgabe(liste);

            int[] gerade = new int [liste.Length];
            int x = 0;
            foreach (var zahl in liste)
            {
                if (zahl == 0)
                {
                    gerade[x] = zahl;
                    x++;
                }
                else if (zahl % 2 == 0)
                {
                    gerade[x] = zahl;
                    x++;
                }
            }
            Console.WriteLine("Die geraden sind:");
            ausgabe(gerade);
        }

        private static void ausgabe(int[] liste)
        {
            int c = 0;
            foreach (var zahl in liste)
            {
                Console.WriteLine($"an Stelle liste[{c}] steht {zahl}");
                c++;
            }
        }
    }
}