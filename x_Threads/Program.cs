using System;
using System.Diagnostics;
using System.Threading;

namespace x_Threads
{
    public class Program
    {
        static volatile int sum = 0;

        public static void Main(string[] args)
        {
            DynamischeThreadsAnzahl();

            // festeThreadAnzahl();

            Console.WriteLine($"Summe ist {sum}");
        }

        private static void festeThreadAnzahl()
        {
            Worker w1 = new Worker();
            Worker w2 = new Worker();
            Worker w3 = new Worker();
            Worker w4 = new Worker();

            Thread t1 = new Thread(() => w1.summieren(0, 2500)) {Name = "t1"};
            Thread t2 = new Thread(() => w2.summieren(2500, 5000)) {Name = "t2"};
            Thread t3 = new Thread(() => w3.summieren(5000, 7500)) {Name = "t3"};
            Thread t4 = new Thread(() => w4.summieren(7500, 10001)) {Name = "t4"};
            Stopwatch StopWatch = new Stopwatch();
            StopWatch.Start();
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            StopWatch.Stop();
            TimeSpan ts = StopWatch.Elapsed;
            Console.WriteLine("Benötigte Zeit: {0:00}.{1:000} [s]", ts.Seconds, ts.Milliseconds);
        }

        private static void DynamischeThreadsAnzahl()
        {
            Stopwatch StopWatch = new Stopwatch();
            StopWatch.Start();
            
            int anzahlThr = 4;
            int parts = 1000000 / anzahlThr;
            Thread[] tr = new Thread[anzahlThr];
            for (int i = 0; i < anzahlThr; i++)
            {
                int a = i * parts;
                int b = a + parts;
                if (i == 3)
                {
                    b += 1;
                }

                Console.WriteLine($"Thread {i} arbeitet von {a} bis ausschließlich {b}");
                Worker w = new Worker();
                Thread t = new Thread(() => w.summieren(a, b)) {Name = $"t{i}"};
                tr[i] = t;
                t.Start();
            }
            

            for (int i = 0; i < anzahlThr; i++)
            {
                tr[i].Join();
            }
            StopWatch.Stop();
            TimeSpan ts = StopWatch.Elapsed;
            Console.WriteLine("Benötigte Zeit: {0:00}.{1:000} [s]", ts.Seconds, ts.Milliseconds);
        }


        public class Worker
        {
            public static object sum_lock = new object();

            public void summieren(int a, int b)
            {
                Console.WriteLine($"Ich hab angefangen etwas zu machen {Thread.CurrentThread.Name}");
                for (int i = a; i < b; i++)
                {
                    lock (sum_lock)
                    {
                        sum += i;
                    }
                }
            }
        }
    }
}