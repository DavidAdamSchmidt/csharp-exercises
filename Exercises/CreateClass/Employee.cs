using System;

namespace CreateClass
{
    internal class Employee : Person, ICloneable
    {
        public decimal Salary { get; set; }
        public string Profession { get; set; }
        public Room Room { get; set; }

        public object Clone()
        {
            var clone = (Employee) MemberwiseClone();

            if (Room != null)
            {
                clone.Room = new Room(Room.Number);
            }

            return clone;
        }

        public override string ToString()
        {
            return base.ToString() + $", Salary = {Salary:C}, Profession = {Profession}, Room = {Room?.Number}";
        }
    }
}
