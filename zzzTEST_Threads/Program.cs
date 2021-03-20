using System;
using System.Threading;

namespace zzzTEST_Threads
{
    class Program {
        static void Main(string[] args) {
            Worker w1 = new Worker(1);
            Worker w2 = new Worker(2);
            Worker w3 = new Worker(3);
            Thread t1 = new Thread(w1.DoWork) {Name = "t1"};
            Thread t2 = new Thread(w2.DoWork) {Name = "t2"};
            Thread t3 = new Thread(w3.DoWork) {Name = "t3"};

            Console.WriteLine("1) {0} | main thread - {1}", DateTime.Now, "started");

            // simply start some threads and wait for their end
            t1.Start();
            t2.Start();
            t3.Start();

            Console.WriteLine("1) {0} | main thread - {1}", DateTime.Now, "threads started, wait for joins");

            //Main wartet for Threads
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("1) {0} | main thread - {1}", DateTime.Now, "threads joined, done");

            //---

            // start a thread and stop it (ThreadStart is a delegate)
            Worker w4 = new Worker(4);
            Thread t4 = new Thread(new ThreadStart(w4.DoWrite)) {Name = "t4"};
            ;

            Console.WriteLine("2) {0} | main thread - {1}", DateTime.Now, "started");
            // start the thread
            t4.Start();
            while (!t4.IsAlive) ; // wait until it is alive - various methods to do so

            Thread.Sleep(2000);
            t4.Abort();
            t4.Join();
            Console.WriteLine("2) {0} | main thread - {1}", DateTime.Now, "threads joined, done");

            //---

            // start a thread and stop it
            Worker w5 = new Worker(5);
            Thread t5 = new Thread(new ThreadStart(w5.DoUntilStop)) {Name = "t5"};
            ;

            Console.WriteLine("3) {0} | main thread - {1}", DateTime.Now, "started");
            // start the thread
            t5.Start();
            while (!t5.IsAlive) ;

            Thread.Sleep(2000);
            w5.shouldStop = true;
            t5.Join();
            Console.WriteLine("3) {0} | main thread - {1}", DateTime.Now, "threads joined, done");

            //---

            // start lambda thread
            Thread t6 = new Thread(() => { Thread.Sleep(1000); }) {Name = "t6"};
            Console.WriteLine("4) {0} | main thread - {1}", DateTime.Now, "started");
            t6.Start();
            Console.WriteLine("4) {0} | main thread - {1}", DateTime.Now, "threads started, wait for joins");
            t6.Join();
            Console.WriteLine("4) {0} | main thread - {1}", DateTime.Now, "threads joined, done");

            Worker w7 = new Worker(7);
            Thread t7 = new Thread(new ParameterizedThreadStart(w7.DoWorkParamObj)) {Name = "t7"};
            ;

            Console.WriteLine("3) {0} | main thread - {1}", DateTime.Now, "started");
            // start the thread
            t7.Start(new Random()); //Parameter für Methode      /\
            t7.Join();
            Console.WriteLine("3) {0} | main thread - {1}", DateTime.Now, "threads joined, done");

            Worker w8 = new Worker(8);
            Thread t8 = new Thread(() => w8.DoWorkParams(42, new Random())) {Name = "t8"};
            ;                               //Parameter für Methode      /\

            Console.WriteLine("3) {0} | main thread - {1}", DateTime.Now, "started");
            // start the thread
            t8.Start();
            t8.Join();
            Console.WriteLine("3) {0} | main thread - {1}", DateTime.Now, "threads joined, done");
        }

        public class Worker {
            public Worker(int _id) {
                id = _id;
            }

            public int id;

            public void DoWork() // threads main method
            {
                Console.WriteLine(
                    "{0} |      thread {1:d},'{2}' - {3}", DateTime.Now, id, Thread.CurrentThread.Name,
                    "started, working");
                Thread.Sleep(id * 1000);
                Console.WriteLine(
                    "{0} |      thread {1:d},'{2}' - {3}", DateTime.Now, id, Thread.CurrentThread.Name, "finished");
            }

            public void DoWrite() // threads main method
            {
                try {
                    while (true) {
                        Console.WriteLine(
                            "{0} |      thread {1:d},'{2}' - {3}", DateTime.Now, id, Thread.CurrentThread.Name,
                            "started, working");
                        Thread.Sleep(500);
                    }
                }
                catch (ThreadAbortException) {
                    Console.WriteLine("ThreadAbortException !");
                }
                finally {
                    Console.WriteLine("finally in case of ThreadAbortException");
                }
            }

            public void DoUntilStop() // threads main method
            {
                while (!shouldStop) {
                    Console.WriteLine(
                        "{0} |      thread {1:d},'{2}' - {3}", DateTime.Now, id, Thread.CurrentThread.Name,
                        "started, working");
                    Thread.Sleep(500);
                }
            }

            public void DoWorkParamObj(Object O) {
                Random R = O as Random;
                Console.WriteLine("  rnd = " + R.Next());
                Console.WriteLine(
                    "{0} |      thread {1:d},'{2}' - {3}", DateTime.Now, id, Thread.CurrentThread.Name,
                    "started, working");
            }

            public void DoWorkParams(int n, Random R) {
                Console.WriteLine("  rnd = " + R.Next() + ", n=" + n);
                Console.WriteLine(
                    "{0} |      thread {1:d},'{2}' - {3}", DateTime.Now, id, Thread.CurrentThread.Name,
                    "started, working");
            }

            // stop via (Kompiler komprimiert nicht)
            public volatile bool shouldStop = false;
        }
    }
}