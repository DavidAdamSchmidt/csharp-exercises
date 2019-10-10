using System;
using System.Collections.Generic;

namespace CreateClass
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var persons = new List<Person>
            {
                new Person
                {
                    Name = "Johnny",
                    BirthDate = new DateTime(1992, 3, 21),
                    Gender = Person.Genders.Male
                },
                new Person
                {
                    Name = "Mary",
                    BirthDate = new DateTime(1995, 6, 5),
                    Gender = Person.Genders.Female
                },
                new Employee
                {
                    Name = "Lucas",
                    BirthDate = new DateTime(1986, 1, 27),
                    Gender = Person.Genders.Male,
                    Salary = 359000.00m,
                    Profession = "Polymath"
                },
                new Employee
                {
                    Name = "Liza",
                    BirthDate = new DateTime(1989, 7, 29),
                    Gender = Person.Genders.Female,
                    Salary = 449333.33m,
                    Profession = "Software Developer",
                    Room = new Room
                    {
                        RoomNumber = 315
                    }
                },
                new Person(),
                new Employee()
            };

            persons.ForEach(Console.WriteLine);
        }
    }
}
