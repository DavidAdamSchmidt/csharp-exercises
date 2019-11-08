# Assignment: Threadings

### Exercise 3: Use the ThreadPool to Queue Work Items

Let's create an application that uses the thread pool to queue up methods to call on separate threads.

### Step by step

1.  Create a blank console application with the name **ThreadPoolDemo**.
2.  Include (or import for Visual Basic) the **System.Threading** namespace.
3.  Create a new static method to simply display some text. Call it **ShowMyText**. Accept one parameter of type object, and call it state.
4.  Create a new string variable inside the **ShowMyText** method, and cast the _state_ parameter to string and store it in the new variable.
5.  Inside the **ShowMyText** method, concatenate the **ManagedThreadId** to the string variable and write the new string out to the console.
6.  In the Main method of the console application, create a new instance of the Threading. **WaitCallback** delegate that refers to the **ShowMyText** method.
7.  Use the Threading.ThreadPool to queue up several calls to the WaitCallback delegate, specifying different strings as the object state.
8.  Build the project, and resolve any errors. Verify that the console application successfully shows each of the calls to the **ShowMyText** methods out to the console.
9.  Commit the changes into your local repository!

Note that some of the work items are executed on different threads.