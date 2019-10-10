using System;

namespace CreateClass
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var johnny = new Person
            {
                Name = "Johnny",
                BirthDate = new DateTime(1992, 3, 21),
                Gender = Person.Genders.Male
            };

            var mary = new Person
            {
                Name = "Mary",
                BirthDate = new DateTime(1995, 6, 5),
                Gender = Person.Genders.Female
            };

            var anonymous = new Person();

            Console.WriteLine(johnny);
            Console.WriteLine(mary);
            Console.WriteLine(anonymous);
        }
    }
}
