using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace X_ThreadPool
{
    internal class Program
    {


        private static volatile List<int> aufgaben;
        private static volatile List<int> results;
        
        public static void Main(string[] args)
        {
            aufgaben = new List<int>();
            aufgaben.Add(1);
            aufgaben.Add(2);
            aufgaben.Add(3);
            aufgaben.Add(4);
            aufgaben.Add(5);
            
            results = new List<int>();
         
            StartMasterWorker(2);

        }

        private static void StartMasterWorker(int anzahlThreads)
        {
          
            Thread[] threads = new Thread[anzahlThreads];
            for (int i = 0; i < anzahlThreads; i++)
            {
                AufgabenWorker w = new AufgabenWorker();

                Thread t = new Thread(w.calcMulti) {Name = $"Thread_{i}"};
                t.Start();

                threads[i] = t;
            }

            foreach (var t in threads)
            {
                t.Join();
            }
            Console.WriteLine($"Alle ergebnisse sind: {String.Join(",", results)}");
        }


        public class AufgabenWorker
        {
            public static object result_lock = new object();
            public void calcMulti()
            {
                while (aufgaben.Count != 0)
                {
                    int zahl = aufgaben[0];
                    aufgaben.RemoveAt(0);
                    int res = zahl * zahl;

                    lock (result_lock)
                    {
                        results.Add(res);   
                    }
                }
            }
        }
    }
}