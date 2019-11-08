using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializePeople
{
    [Serializable]
    public class Person
    {
        public enum Genders
        {
            Male,
            Female
        }

        private readonly DateTime _currentDate;

        public Person()
        {
            _currentDate = DateTime.Now;
        }

        public Person(DateTime currentDate)
        {
            _currentDate = currentDate;
        }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Genders Gender { get; set; }
        public int Age => CalculateAge();

        public static Person Deserialize(string fileName)
        {
            Person person;
            IFormatter formatter = new BinaryFormatter();

            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                person = formatter.Deserialize(stream) as Person;
            }

            return person;
        }

        public void Serialize(string output)
        {
            IFormatter formatter = new BinaryFormatter();

            using (Stream stream = new FileStream(output, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, this);
            }
        }

        public override string ToString()
        {
            return $"Name = {Name}, BirthDate = {BirthDate:yyyy-MM-dd}, Gender = {Gender}, Age = {Age}";
        }

        private int CalculateAge()
        {
            var now = int.Parse(_currentDate.ToString("yyyyMMdd"));
            var born = int.Parse(BirthDate.ToString("yyyyMMdd"));

            return (now - born) / 10000;
        }
    }
}
