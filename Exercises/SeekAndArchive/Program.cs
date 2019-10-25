using System;
using System.IO;

namespace SeekAndArchive
{
    internal class Program
    {
        private static int _match;

        private static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                var message = $"Invalid amount of arguments provided (expected 2, received {args.Length}).";
                throw new ArgumentException(message);
            }

            var file = new FileInfo(args[0]);
            var directory = new DirectoryInfo(args[1]);

            Console.WriteLine($"Searching for {file.Name} in {directory.FullName}...");
            SearchForFile(file, directory);
            Console.WriteLine($"Search ended with {_match} match{(_match == 1 ? "" : "es")}.");
        }

        private static void SearchForFile(FileInfo file, DirectoryInfo directory)
        {
            foreach (var f in directory.GetFiles())
            {
                if (f.Name == file.Name)
                {
                    Console.WriteLine($"Found a match in {f.DirectoryName}");
                    _match++;
                }
            }

            foreach (var d in directory.GetDirectories())
            {
                SearchForFile(file, d);
            }
        }
    }
}
