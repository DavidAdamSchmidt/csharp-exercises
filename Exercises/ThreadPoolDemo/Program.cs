using System;
using System.Threading;

namespace ThreadPoolDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var callback = new WaitCallback(ShowMyText);

            ThreadPool.QueueUserWorkItem(callback, "Python");
            ThreadPool.QueueUserWorkItem(callback, "JavaScript");
            ThreadPool.QueueUserWorkItem(callback, "Java");
            ThreadPool.QueueUserWorkItem(callback, "C#");

            Console.ReadKey();
        }

        private static void ShowMyText(object state)
        {
            Console.WriteLine($"Text: {state}, Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
