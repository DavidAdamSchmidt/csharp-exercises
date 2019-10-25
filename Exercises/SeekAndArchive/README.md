# Assignment: Searching for a file

## Task

Using Visual Studio, create a new console application project. Name the project _SeekAndArchive_. We would like to create an application which watches a selected group of files, and automatically creates a compressed archive of them when any of them changes.

As a first step we would like to provide some searching functionality. Let the application have two command arguments: the first is the file we are looking for, and the second is the directory we must perform the recursive searching.

As an output, list the path of the files found matching the name.

### Hint

Use [DirectoryInfo](https://docs.microsoft.com/en-us/dotnet/api/system.io.directoryinfo?view=netframework-4.7.2) and [FileInfo](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileinfo?view=netframework-4.7.2) (why is it better?). Write a recursive algorithm that traverse all the subdirectories and matches the file names to the search criteria. To set up command arguments, right click to the project in the Solution Explorer, then configure command arguments (separated by spaces) for debugging.

# Assignment: Searching for a file - Advanced task

## Exercise 1: File watching

### Task

Use the application you created in the previous exercise _Searching for a file_. Create a filewatcher (or filewatchers) which watches if any of the found files gets modified. Display a message on the console if any modification happens to these files. (now we only watch content changes, and assume for simplicity that the files are not deleted.)

### Hint

You might need several [FileSystemWatcher](https://docs.microsoft.com/en-us/dotnet/api/system.io.filesystemwatcher?view=netframework-4.7.2) objects.

### Advanced task

Watch also if the files are being deleted or renamed, and update the file list accordingly. So if a file is deleted, remove it from the watching list, and also remove its file watcher.

## Exercise 2: Automatically create archives

### Task

Now continue from Exercise 1. Create a custom directory for your archives, and do the following: if any of the files on your list is modified, automatically perform archivation by compressing the file into your temporary directory.

### Hint

Use a different directory for each file since they have the same name.

### Advanced task

Since you are archiving files, use individual names for your archives. This could be done by adding an increment to the file name, like _file1.gz_, _file2.gz_ etc. Or by concatenating the time to the end of the filename. The Path class can make this task easier.

## Exercise 3: Store the archive files in Isolated Storage

### Task

Modify your application that it stores the archived files in [Isolated Storage](https://docs.microsoft.com/en-us/dotnet/standard/io/isolated-storage).