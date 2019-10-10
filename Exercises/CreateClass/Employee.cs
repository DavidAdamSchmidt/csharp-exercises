namespace CreateClass
{
    internal class Employee : Person
    {
        public decimal Salary { get; set; }
        public string Profession { get; set; }
        public Room Room { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Salary = {Salary:C}, Profession = {Profession}, Room = {Room?.RoomNumber}";
        }
    }
}
