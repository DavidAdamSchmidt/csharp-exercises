using System;
using System.Threading;

namespace SimpleThreadingDemo
{
    internal class Program
    {
        private static void Main(string[] args)
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
