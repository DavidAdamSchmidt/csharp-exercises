using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.IO.IsolatedStorage;

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

            var file = new FileInfo(e.FullPath);

            CompressFile(file);
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

        private static DirectoryInfo CreateDirectoryForArchives(FileInfo file)
        {
            var directoryName = Path.GetDirectoryName(file.FullName);

            return Directory.CreateDirectory(Path.Combine(directoryName, "Archives"));
        }

        private static string GetPathForCompression(FileInfo file, DirectoryInfo directory)
        {
            var simpleFileName = Path.GetFileNameWithoutExtension(file.Name);
            var time = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var fileName = string.Concat(simpleFileName, time, file.Extension);

            return $"{Path.Combine(directory.FullName, fileName)}.gz";
        }

        private static void CompressFile(FileInfo file)
        {
            var directory = CreateDirectoryForArchives(file);
            var path = GetPathForCompression(file, directory);

            using (var fileStream = file.OpenRead())
            {
                using (var compressedFileStream = File.Create(path))
                {
                    using (var compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                    {
                        fileStream.CopyTo(compressionStream);
                    }
                }
            }

            Console.WriteLine($"{file.FullName} has been archived as {path}");

            ArchiveIntoIsolatedStorage(new FileInfo(path));
        }

        private static void ArchiveIntoIsolatedStorage(FileInfo file)
        {
            var isoStore =
                IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            using (var isoStream = new IsolatedStorageFileStream(file.Name, FileMode.Create, isoStore))
            {
                using (var fileStream = new FileStream(file.FullName, FileMode.Open))
                {
                    fileStream.CopyTo(isoStream);
                }
            }

            Console.WriteLine($"{file.FullName} has been archived into the isolated storage.");
        }
    }
}
