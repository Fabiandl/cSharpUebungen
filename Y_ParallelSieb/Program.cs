using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

// http://de.wikipedia.org/wiki/Sieb_des_Eratosthenes

namespace Y_ParallelSieb {
    class Program {
        class SiebSimple {
            public bool[] Sieb;

            public long Size { get; set; }

            public SiebSimple(long n) {
                Size = n;
                Sieb = new bool[Size];
            }

            public void Reset() {
                for (long i = 0; i < Size; ++i)
                    Sieb[i] = false;
            }

            // ganz einfache Variante!
            public void CalcPrimes() {
                Sieb[0] = Sieb[1] = true; // not prime
                for (long i = 2; i < Size; ++i) {
                    if (Sieb[i])
                        continue;
                    for (long k = i + i; k < Size; k += i)
                        Sieb[k] = true;
                }
            }
        }

        static void Main(string[] args) {
            const long n = 100;
            SiebSimple S = new SiebSimple(n);
            Stopwatch StopWatch = new Stopwatch();

            S.Reset();
            StopWatch.Start();
            S.CalcPrimes();
            StopWatch.Stop();
            TimeSpan ts = StopWatch.Elapsed;

            Console.WriteLine("Benötigte Zeit: {0:00}.{1:000} [s]", ts.Seconds, ts.Milliseconds);
            Console.Write("Größten 10 Primzahlen:");
            for (long i = n - 1, cnt = 0; i >= 0 && cnt < 10; --i)
                if (!S.Sieb[i]) {
                    Console.Write(" " + i);
                    ++cnt;
                }

            Console.WriteLine();

            // und jetzt parallel ... 
            Stopwatch StopWatch2 = new Stopwatch();
            StopWatch2.Start();
            var boolParal = parallelSieb(n);
            StopWatch2.Stop();
            TimeSpan ts2 = StopWatch2.Elapsed;
            
            Console.WriteLine("Benötigte Zeit: {0:00}.{1:000} [s]", ts2.Seconds, ts2.Milliseconds);
            Console.Write("Größten 10 Primzahlen:");
            for (long i = n - 1, cnt = 0; i >= 0 && cnt < 10; --i)
                if (!boolParal[i]) {
                    Console.Write(" " + i);
                    ++cnt;
                }
        }

        private static bool[] parallelSieb(long n)
        {
            Sieb = new bool[n+1];
            Sieb[0] = Sieb[1] = true; // not prime

            WorkerSiebSimple w1 = new WorkerSiebSimple();
            WorkerSiebSimple w2 = new WorkerSiebSimple();
            WorkerSiebSimple w3 = new WorkerSiebSimple();
            WorkerSiebSimple w4 = new WorkerSiebSimple();

            Thread t1 = new Thread(() => w1.CalcPrimes(0, 25));
            Thread t2 = new Thread(() => w2.CalcPrimes(26, 50));
            Thread t3 = new Thread(() => w3.CalcPrimes(51, 75));
            Thread t4 = new Thread(() => w4.CalcPrimes(76, 100));

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            
            return Sieb;
        }

        static volatile bool[] Sieb;
        
        public static object first_lock = new object();
        class WorkerSiebSimple {
            
            // ganz einfache Variante!
            public void CalcPrimes(int a, int b) {
                if (a == 0)
                {
                    a = 2;
                }
                for (long i = a; i <= b; ++i)
                {
                    lock (first_lock)
                    {
                        if (Sieb[i])
                            continue;
                        for (long k = i + i; k < b; k += i)
                            Sieb[k] = true;
                    }
                }
            }
        }
    }
}