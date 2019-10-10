using System;

namespace CreateClass
{
    internal class Person
    {
        public enum Genders
        {
            Male,
            Female
        }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Genders Gender { get; set; }

        public override string ToString()
        {
            return $"Name = {Name}, BirthDate = {BirthDate:yyyy-MM-dd}, Gender = {Gender}";
        }
    }
}
