using System;
using System.Collections.Generic;
using System.Linq;

namespace U_EnumFindAll
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string text = "012mmmm7890mmm";

            List<int> pos = FindAll(text, "mm");
            
            Console.WriteLine(String.Join(",",pos));

            Console.WriteLine($"Enum FindAll: {string.Join(", ", enumFindAll(text,"mm"))}");
        }

        private static IEnumerable<int> enumFindAll(string text, string muster)
        {

            bool nothingElse = false;
            
            int diff = 0;
            while(!nothingElse)
            {
                int k = text.IndexOf(muster);
                
                if (k != -1)
                {
                    yield return k + diff;
                    text = text.Remove(k,2);
                    diff += muster.Length;
                }
                else
                {
                    nothingElse = true;
                }
            }
        }
        

        private static List<int> FindAll(string text, string muster)
        {
            List<int> res = new List<int>();

            bool nothingElse = false;
            
            int diff = 0;
            while(!nothingElse)
            {
                int k = text.IndexOf(muster);
                
                if (k != -1)
                {
                    res.Add(k + diff);
                    text = text.Remove(k,2);
                    diff += muster.Length;
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