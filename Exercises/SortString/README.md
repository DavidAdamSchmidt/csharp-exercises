# Working with strings

## Step by step

In this exercise, you will write a function to sort a string.

1. Using Visual Studio, create a new console application project. Name the project _SortString_.
2. Define a string. Then use the _String.Split_ method to separate the string into an array of words. The following code demonstrates this:

    ```csharp
    string str = "Microsoft .NET Framework 2.0 Application Development Foundation";
    string[] words = str.Split(' ');
    ```

3. Call the _Array.Sort_ method to sort the array of words, as the following code demonstrates:

    ```csharp
   Array.Sort(words);
    ```

4. Call the _String.Join_ method to convert the array of words back into a single string, and then write the string to the console. The following code sample demonstrates this:

    ```csharp
    s = string.Join(" ", words);
    Console.WriteLine(s);
    ```

5. Run the console application, and verify that it works correctly.
