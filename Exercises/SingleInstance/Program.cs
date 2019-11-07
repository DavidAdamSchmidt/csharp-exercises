using System;
using System.Threading;

namespace SingleInstance
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Mutex mutex;
            const string name = "RUNMEONLYONCE";

            while (true)
            {
                Thread.Sleep(1000);
                try
                {
                    Console.WriteLine("In the try block.");

                    mutex = Mutex.OpenExisting(name);
                    mutex?.Close();

                    Environment.Exit(0);
                }
                catch (WaitHandleCannotBeOpenedException)
                {
                    Console.WriteLine("In the catch block.");

                    new Mutex(false, name);
                }
            }
        }
    }
}
