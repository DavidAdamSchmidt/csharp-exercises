using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleThreadingDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "tpl")
            {
                Console.WriteLine($"using System.Threading.Tasks{Environment.NewLine}");

                CreateTasks();
            }
            else
            {
                Console.WriteLine($"using System.Threading{Environment.NewLine}");

                CreateThreads();
            }
        }

        private static void CreateTasks()
        {
            var task1 = Task.Factory.StartNew(Counting);
            var task2 = Task.Factory.StartNew(Counting);

            Task.WaitAll(task1, task2);
        }

        private static void CreateThreads()
        {
            var thread1 = new Thread(Counting);
            var thread2 = new Thread(Counting);

            thread1.Start();
            thread2.Start();
        }

        private static void Counting()
        {
            for (var i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Count: {i}, Thread ID: {Thread.CurrentThread.ManagedThreadId}");

                Thread.Sleep(10);
            }
        }
    }
}
