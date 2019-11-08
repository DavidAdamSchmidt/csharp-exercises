using System;

namespace SerializePeople
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var erwin = new Person(new DateTime(2019, 11, 8))
            {
                Name = "Erwin",
                BirthDate = new DateTime(1978, 11, 9),
                Gender = Person.Genders.Male
            };

            Console.WriteLine(erwin);
        }
    }
}
