# Assignment: Threadings

### Exercise 2: Use a Mutex to Create a Single-Instance Application

Let's create a simple console application in which you will use a Mutex to ensure there is only one instance of the application running at any point.

### Step by step

1.  Create a new console application called **SingleInstance**.
2.  In the main code file, include **System.Threading**.
3.  In the main method of the console application, create a local **Mutex** variable and assign it a null
4.  Create a constant string to hold the name of the shared Mutex. Make the value _"RUNMEONLYONCE"_.
5.  Create a try/catch block.
6.  Inside the try section:
    -   call the **Mutex.OpenExisting** method, using the constant string defined previously as the name of the Mutex
    -   Assign the result to the Mutex variable created before
    -   close the Mutex variable and exit the application
7.  For the catch section:
    -   catch the **WaitHandleCannotBeOpenedException** to determine that the named Mutex doesn't exist and create the Mutex with the constant string as a name
8.  Put the whole try/catch block into an infinite while loop.
9.  Build the project, and resolve any errors. Verify that only one instance of the application can be run at once.
10. Commit the changes into your local repository!