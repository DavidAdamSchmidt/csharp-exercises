using System;

namespace SortString
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string str = "Microsoft .NET Framework 2.0 Application Development Foundation";
            var words = str.Split(' ');
            Array.Sort(words);
            var result = string.Join(" ", words);
            Console.WriteLine(result);
        }
    }
}
