using System;

namespace SerializePeople
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var erwin = new Person
            {
                Name = "Erwin",
                BirthDate = new DateTime(1978, 5, 5),
                Gender = Person.Genders.Male
            };

            erwin.Serialize("erwin.bin");

            Console.WriteLine(erwin);
        }
    }
}
