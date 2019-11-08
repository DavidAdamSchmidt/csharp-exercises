using System;

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
