using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace V_LINQ
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Randoms
            Random random = new Random();
            IEnumerable<int> alle = Enumerable.Range(1, 20).Select(n => random.Next(0, 100));
            IEnumerable<int> ungerade = alle.Where(n => n % 2 != 0);
            Console.WriteLine($"Gerade {string.Join(", ", alle)}");
            Console.WriteLine($"Ungerade Zufallszalhen: {string.Join(",", ungerade)}");

            //Groups
            var groups =
                from n in alle
                group n by n % 5
                into g
                orderby g.Key
                select new {rem = g.Key, cnt = g.Count()};

            foreach (var g in groups)
            {
                Console.WriteLine($"Gruppe n%5={g.rem}, cnt={g.cnt}");
            }
            
            //XML Lesen
            string fileName = "../../../V_LINQ/simple.xml";
            
            string[] lines = File.ReadAllLines(fileName);

            var start = lines.Where(n => n.Contains("name")).Where(line => line.Contains("Waffles"));
            var xmlWaffles = lines.Where(n => n.Contains("name")).Where(line => line.Contains("Waffles")).Select(n => n.Substring(n.IndexOf(">")+1,n.IndexOf("Waffles")- n.IndexOf(">")+6));
            
            Console.WriteLine($"Alle Waffles : {string.Join(",",start)}");
            Console.WriteLine($"Alle Waffles : {string.Join(",",xmlWaffles)}");
        }
    }
}