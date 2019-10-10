# CreateClass

## Exercise 1: Create new Person class

### Task

1. Using Visual Studio, create a new console application project. Take care to target .NET Framework instead of .NET core! Name the project _CreateClass_.
2. Make a class named Person.
3. Let this class have the following properties: Name, BirthDate (choose the data type you might think suitable).
4. Also add an enumeration to your class, called Genders. The person can be Male or Female!
5. Override the ToString() method of the Person, and return some information about the class in it.
6. Write some code to try it out in the _Main_ method.

## Exercise 2: Derive from Person

### Task

1. Add a new class to your _CreateClass_ project called Employee. Derive this class from Person, since an Employee is a person.
2. Let the employee have new properties like Salary and Profession.
3. Override the ToString() method of the Person in order to return these new pieces of information as well.
4. Extend the Employee class to have a reference to a Room class. Let the Room class be a simple class with a single integer, the room number.
5. Don't forget to test your code! Write at least a main method what creates instances or you can also google how to make unit tests and make some.

## Exercise 3: Clone Wars

### Task

This exercise is about cloning, and the meaning of deep and shallow copy. Modify the Employee class to implement the ICloneable interface. Try the following code snippets in the definition of the Clone method:

1. Clone without room

    ```csharp
    public object Clone()
    {
        return this.MemberwiseClone();
    }
    ```

2. Clone with room as well

    ```csharp
    public object Clone()
    {
        Employee newEmployee = (Employee)this.MemberwiseClone();
        newEmployee.Room = new Room(Room.Number);
        return newEmployee;
    }
    ```

For both cases execute the following main method:

```csharp
class Program
{
   static void Main(string[] args)
   {
       Employee Kovacs = new Employee("Géza", DateTime.Now, 1000, "léhűtő");
       Kovacs.Room = new Room(111);
       Employee Kovacs2 = (Employee)Kovacs.Clone();
       Kovacs2.Room.Number = 112;
       Console.WriteLine(Kovacs.ToString());
       Console.WriteLine(Kovacs2.ToString());
       Console.ReadKey();
   }
}
```

What happens?

### Step by step

In order to implement the ICloneable interface, do the following modifications:

1. Extend the Employee class definition with the name of the ICloneable interface:

    ```csharp
    class Employee : Person, ICloneable
    ```

2. Implement the Clone() method as described previously
