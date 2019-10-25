# Assignment: Searching for a file

## Task

Using Visual Studio, create a new console application project. Name the project _SeekAndArchive_. We would like to create an application which watches a selected group of files, and automatically creates a compressed archive of them when any of them changes.

As a first step we would like to provide some searching functionality. Let the application have two command arguments: the first is the file we are looking for, and the second is the directory we must perform the recursive searching.

As an output, list the path of the files found matching the name.

### Hint

Use [DirectoryInfo](https://docs.microsoft.com/en-us/dotnet/api/system.io.directoryinfo?view=netframework-4.7.2) and [FileInfo](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileinfo?view=netframework-4.7.2) (why is it better?). Write a recursive algorithm that traverse all the subdirectories and matches the file names to the search criteria. To set up command arguments, right click to the project in the Solution Explorer, then configure command arguments (separated by spaces) for debugging.