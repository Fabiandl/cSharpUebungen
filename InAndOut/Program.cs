using System;
using System.Collections.Generic;
using System.IO;

namespace InAndOut11
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string fileName = "../../../InAndOut/bundesliga";
            
            string[] lines = File.ReadAllLines(fileName + "-0.txt");
            
            using ( StreamWriter writer = new StreamWriter(fileName + "-1.txt")) 
            { 
                for (int i = lines.Length-1; i >= 0; i--) 
                { 
                    writer.WriteLine(lines[i]);
                }
            }

            List<Verein> vereine = new List<Verein>();
            for (int i = 0; i < lines.Length; i++)
            {
                Verein verein = new Verein(lines[i].Substring(0, 25), i+1);
                verein.addErgebnisse(lines[i].Substring(26));
                
                vereine.Add(verein);
            }

            foreach (var verein in vereine)
            {
                Console.WriteLine(verein);
            }
            
            using ( StreamWriter writer = new StreamWriter(fileName + "-2.txt")) 
            { 
                foreach (var verein in vereine)
                { 
                    writer.WriteLine(verein);
                }
            }
        }
    }
}