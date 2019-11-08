# Assignment: Serialization

### Exercise 1: Make a Class Serializable

In this exercise, you modify a custom class so that developers can easily store it to the disk for later retrieval or transfer it across a network to another .NET Framework application. Open the C# project in the _first SI week_ and find the _Person class_. You need to modify it to make it serializable. What would you do?

#### Requirements

1.  Create a project named **SerializePeople** and re-create the same Person class in it as you did on your first week.
2.  Examine the **Person** class. It should have _Name_ (string), _BirthDate_ (DateTime), _Gender_ (Genders enum), _Age_ (int) properties. Create the properties if some of them are missing.
3.  The Person's _Age_ should be calculated based on the current date.
4.  What changes do you need to make so that the **Person** class is serializable? You must add the **Serializable** attribute.
5.  Add the _System.Runtime.Serialization_ namespace to the class.
6.  Build the project to ensure it compiles correctly.
7.  **Make Unit Tests** to test the instance creation and the _ToString_ method!

### Exercise 2: Serialize an Object

In this exercise, you write code to store an object to the disk using the most efficient method possible.

#### Requirements

1.  Open the **SerializePeople** project
2.  Create a _Serialize_ method in Person class and implement it. The skeleton of the method is here, you should implement the missing parts

    ```csharp
    public void Serialize(string output)
    {
        // Create file to save the data
        // Create and use a BinaryFormatter object to perform the serialization
        // Close the file
    }
    ```

3.  Build the project, and resolve any errors
4.  **Make Unit Tests** to test the serialization. Don't forget to include deletion of the file in the start. That way you can check if the file was created
5.  Examine the serialized data by opening the file your application produced to verify that the name you entered was successfully captured. The date and age information are contained in the serialized data as well; however, they are less easy to interpret in Notepad

### Exercise 3: Deserialize an Object

In this exercise, you must read an object from the disk that has been serialized by using **BinaryFormatter**.

#### Requirements

1.  Open the **SerializePeople** project you modified in Exercises 1 and 2
2.  Make a **Deserialize** method in the Person class to deserialize the file into a Person object. Your code could look like the following, implement the missing parts:

    ```csharp
    public static Person Deserialize()
    {
        Person person = new Person(); // notice that Person should have a default constructor
        // Open file to read the data from
        // Create a BinaryFormatter object to perform the deserialization
        // Use the BinaryFormatter object to deserialize the data from the file
        // Close the file and return with the brand-new Person object
    }
    ```

3.  Build the project and resolve any errors
4.  **Make Unit Tests** to test the deserialization. Don't forget to include deletion of the file in the start. I would think in a serialization-deserialization pair as a test.

### Exercise 4: Optimize a Class for Deserialization

In this exercise, you modify a class to improve the efficiency of serialization.

#### Requirements

1.  Open the **SerializePeople** project you modified in Exercises 1, 2, and 3.
2.  Modify the **Person** class to prevent the _Age_ member from being serialized. To do this, add the **NonSerialized** attribute to the member.
3.  Build and run the project
4.  Note that the deserialized Person object's Age will be zero because we are not serializing the age anymore
5.  Modify the Person class to implement the **IDeserializationCallback** interface (and check out what this interface does)
6.  Implement the interface. Basically you should calculate the age again
7.  Build and run the project. Note that the age displays properly this time because it is calculated immediately after deserialization thanks to the **IDeserializationCallback** interface
8.  Update Unit tests if needed

### Exercise 5: Update a Class to Use Custom Serialization

In this exercise, you will update a class to improve the efficiency of serialization while maintaining complete control over how data is stored and retrieved. You can continue your C# project.

#### Requirements

1.  Add the **System.Runtime.Serialization** namespace to the **Person** class.
2.  Add the **[Serializable**] attribute to the **Person** class, and then build the project to ensure it compiles correctly.
3.  Modify the **Person** class so that it implements **ISerializable**. Check out an example how to implement this interface.
4.  Add the GetObjectData method. Add the name, birth date, gender variables to the SerializationInfo object, but do not add the age variable. This method is needed for ISerializable so if you don't know what it does check it on Google
5.  Add the serialization constructor (also needed for serialization). Fill the name, birth of date, gender from the serialization info. After you have deserialized all variables, calculate the age to initialize the age variable
6.  Build the project, and resolve any errors
7.  Update unit tests if needed