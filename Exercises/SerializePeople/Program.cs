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

            const string fileName = "erwin.bin";

            erwin.Serialize(fileName);

            var erwin2 = Person.Deserialize(fileName);

            Console.WriteLine("Original:");
            Console.WriteLine($"{erwin}{Environment.NewLine}");
            Console.WriteLine("Deserialized:");
            Console.WriteLine($"{erwin2}{Environment.NewLine}");
            Console.WriteLine($"The properties of these object are equal: {erwin.ToString() == erwin2.ToString()}");
        }
    }
}
