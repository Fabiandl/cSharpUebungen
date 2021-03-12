using System;
using System.Threading.Tasks;

namespace zz_Tasks
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            // iterativeTasks();

            dynamicTasks(4);
        }

        private static void dynamicTasks(int anzahl)
        {
            object sum_lock = new object();
            int sum = 0;

            int part = 10000 / 4;

            Task[] tasks = new Task[anzahl];

            for (int i = 0; i < anzahl; i++)
            {
                int diff = 0;
                if (i == anzahl-1)
                {
                    diff++;
                }
                int a = i * part;
                int b = a + part;
                int id = i+1;
                Task t = Task.Run(
                    () =>
                    {
                        Console.WriteLine($"-- T{id}: performing task with {a} : {b}");
                        int temp = 0;
                        for (int j = a; j < b + diff; j++)
                        {
                            temp += j;
                        }

                        lock (sum_lock)
                        {
                            Console.WriteLine($"T{id} temp = {temp}");
                            sum += temp;
                        }
                    });
                tasks[i] = t;
            }

            foreach (var t in tasks)
            {
                t.Wait();
            }
            Console.WriteLine($"Summe ist: {sum}");
        }

        private static void iterativeTasks()
        {
            object sum_lock = new object();
            int sum = 0;
            Task T1 = Task.Run(
                () =>
                {
                    Console.WriteLine("-- T1: performing task");
                    int temp = 0;
                    for (int i = 0; i < 2500; i++)
                    {
                        temp += i;
                    }

                    lock (sum_lock)
                    {
                        Console.WriteLine($"T1 temp = {temp}");
                        sum += temp;
                    }
                });
            Task T2 = Task.Run(
                () =>
                {
                    Console.WriteLine("-- T2: performing task");
                    int temp = 0;
                    for (int i = 2500; i < 5000; i++)
                    {
                        temp += i;
                    }

                    lock (sum_lock)
                    {
                        Console.WriteLine($"T2 temp = {temp}");
                        sum += temp;
                    }
                });
            Task T3 = Task.Run(
                () =>
                {
                    Console.WriteLine("-- T3: performing task");
                    int temp = 0;
                    for (int i = 5000; i < 7500; i++)
                    {
                        temp += i;
                    }

                    lock (sum_lock)
                    {
                        Console.WriteLine($"T3 temp = {temp}");
                        sum += temp;
                    }
                });
            Task T4 = Task.Run(
                () =>
                {
                    Console.WriteLine("-- T4: performing task");
                    int temp = 0;
                    for (int i = 7500; i < 10001; i++)
                    {
                        temp += i;
                    }

                    lock (sum_lock)
                    {
                        Console.WriteLine($"T4 temp = {temp}");
                        sum += temp;
                    }
                });

            T1.Wait();
            T2.Wait();
            T3.Wait();
            T4.Wait();

            Console.WriteLine($"Summe ist: {sum}");
        }
    }
}