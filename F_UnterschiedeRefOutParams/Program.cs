using System;

namespace UnterschiedeRefOutParams
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int a = 1;
            int b = 2;
            
            Console.WriteLine($"a = {a}, b = {b}");

            swap(ref a, ref b);
            
            Console.WriteLine($"a = {a}, b = {b}");

            int[] array = new int[10];

            fillWithRandom(ref array);
            
            Console.WriteLine(String.Join(",",array));
            
            Console.WriteLine(getParamsLength(1,2,3,4,5));
        }

        private static int getParamsLength(params int[] param)
        {
            return param.Length;
        }
        
        private static void fillWithRandom(ref int[] array)
        {
            Random ran = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = ran.Next();
            }
        }

        private static void swap(ref int a, ref int b)
        {
            int tempb = b;

            b = a;
            a = tempb;
        }
    }
}