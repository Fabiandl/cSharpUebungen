using System;
using System.Collections.Generic;

namespace StringFindAll
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string text = "abcHalloabcHallo";

            List<int> pos = FindAll(text);
            
            Console.WriteLine(String.Join(",",pos));
        }

        private static List<int> FindAll(string text)
        {
            List<int> res = new List<int>();

            bool nothingElse = false;
            
            while(!nothingElse)
            {
                int k = text.IndexOf("abc");
                if (k != -1)
                {
                    res.Add(k);
                    text = text.Remove(k,3);
                }
                else
                {
                    nothingElse = true;
                }
            }

            return res;
        }
    }
}