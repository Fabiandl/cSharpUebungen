using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace zzz_Probeklausur
{
    internal class Program
    {
        static volatile SortedSet<int> set_A = new SortedSet<int>();
        static volatile SortedSet<int> set_V = new SortedSet<int>();
        static volatile SortedSet<int> set_D = new SortedSet<int>();

        public static void Main(string[] args)
        {
            //a)
            Console.WriteLine(AlgebraWorker.checkZahl(12)); //Abundant
            Console.WriteLine(AlgebraWorker.checkZahl(6)); //Vollkommen
            Console.WriteLine(AlgebraWorker.checkZahl(2)); //defizit

            //b)
            startCheckZahlen(4);
            Console.WriteLine("Set-A");
            DisplaySet(set_A);
            Console.WriteLine("Set-V");
            DisplaySet(set_V);
            Console.WriteLine("Set-D");
            DisplaySet(set_D);
            
            //c)
            var menge = set_A.Where(n => n % 10 == 0)
                .Select(n => new {zahl = n, summe = AlgebraWorker.QuersummeBerechnen(n)});

            foreach (var pair in menge)
            {
                string str = $"Zahl = {pair.zahl}, mit Quersumme {pair.summe}";
                Console.WriteLine(str);
            }
        }
        
        public static void DisplaySet(SortedSet<int> collection)
        {
            Console.Write("{");
            foreach (int i in collection)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine(" }");
        }

        private static void startCheckZahlen(int anzahlThreads)
        {
            int parts = 100 / anzahlThreads;
            Thread[] tr = new Thread[anzahlThreads];
            for (int i = 0; i < anzahlThreads; i++)
            {
                int a = i * parts;
                if (a == 0)
                {
                    a = 1;
                }
                int b = a + parts;

                Console.WriteLine($"Thread {i} arbeitet von {a} bis ausschließlich {b}");
                AlgebraWorker w = new AlgebraWorker();
                Thread t = new Thread(() => w.doMyChecking(a, b)) {Name = $"t{i}"};
                tr[i] = t;
                t.Start();
            }
            for (int i = 0; i < anzahlThreads; i++)
            {
                tr[i].Join();
            }

            Console.WriteLine("Fertig");
        }
        
        public class AlgebraWorker
        {
            //Mutex lock
            public static object a_lock = new object();
            public static object v_lock = new object();
            public static object d_lock = new object();

            //Methode die ausgeführt werden soll
            public void doMyChecking(int a, int b)
            {
                Console.WriteLine($"Ich hab angefangen etwas zu machen {Thread.CurrentThread.Name}");
                for (int zahl = a; zahl < b; zahl++)
                {
                    int res = checkZahl(zahl);
                    switch (res)
                    {
                        case 0:
                            lock (a_lock)
                            {
                                set_A.Add(zahl);
                                break;
                            }
                        case 1:
                            lock (v_lock)
                            {
                                set_V.Add(zahl);
                                break;
                            }
                        case 2:
                            lock (d_lock)
                            {
                                set_D.Add(zahl);
                                break;
                            }
                        default:
                            Console.WriteLine($"Error with Zahl {a}");
                            break;
                    }
                }
            }

            public static int checkZahl(int a)
            {
                var quersumme = QuersummeBerechnen(a);

                if (quersumme > a)
                {
                    return 0;
                }
                else if (quersumme == a)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }

            public static int QuersummeBerechnen(int a)
            {
                int quersumme = 0;
                for (int teiler = 1; teiler <= a / 2; teiler++)
                {
                    if (a % teiler == 0)
                    {
                        quersumme += teiler;
                    }
                }
                return quersumme;
            }
        }
    }
}