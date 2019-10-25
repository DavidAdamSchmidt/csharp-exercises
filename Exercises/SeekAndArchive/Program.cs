using System;
using System.Collections.Generic;
using System.IO;

namespace SeekAndArchive
{
    internal class Program
    {
        private static int _match;
        private static readonly List<FileSystemWatcher> Watchers = new List<FileSystemWatcher>();

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

            if (_match > 0)
            {
                Console.WriteLine("Waiting for a modification on these files...");
                Console.WriteLine("Press any key to quit.");
                Console.ReadKey();
            }

            DisposeWatchers();
        }

        private static void SearchForFile(FileInfo file, DirectoryInfo directory)
        {
            foreach (var f in directory.GetFiles())
            {
                if (f.Name == file.Name)
                {
                    Console.WriteLine($"Found a match in {f.DirectoryName}");
                    _match++;
                    AddWatcher(f, directory);
                }
            }

            foreach (var d in directory.GetDirectories())
            {
                SearchForFile(file, d);
            }
        }

        private static void AddWatcher(FileInfo file, DirectoryInfo directory)
        {
            var watcher = new FileSystemWatcher(directory.FullName)
            {
                Filter = file.Name,
                EnableRaisingEvents = true
            };
            watcher.Changed += OnChanged;
            watcher.Renamed += OnRenamed;
            watcher.Deleted += OnDeleted;

            Watchers.Add(watcher);
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.FullPath} was changed at {DateTime.Now}");
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"{e.OldFullPath} was renamed to {e.Name} at {DateTime.Now}");

            RemoveWatcher(e);
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.FullPath} was deleted at {DateTime.Now}");

            RemoveWatcher(e);
        }

        private static void RemoveWatcher(FileSystemEventArgs e)
        {
            Watchers.RemoveAll(w => Path.Combine(w.Path, e.Name) == e.FullPath);

            Console.WriteLine($"{e.FullPath} is no longer being monitored.");
        }

        private static void DisposeWatchers()
        {
            Watchers.ForEach(w => w.Dispose());
        }
    }
}
