using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializePeople
{
    [Serializable]
    public class Person : IDeserializationCallback, ISerializable
    {
        public enum Genders
        {
            Male,
            Female
        }

        [NonSerialized] private int _age;
        private DateTime _birthDate;
        private readonly DateTime _currentDate;

        public Person()
        {
            _currentDate = DateTime.Now;
        }

        public Person(DateTime currentDate)
        {
            _currentDate = currentDate;

        }

        public Person(SerializationInfo info, StreamingContext context)
            : this()
        {
            Name = (string) info.GetValue("Name", typeof(string));
            _birthDate = (DateTime) info.GetValue("_birthDate", typeof(DateTime));
            Gender = (Genders) info.GetValue("Gender", typeof(Genders));

            CalculateAge();
        }

        public string Name { get; set; }

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                CalculateAge();
            }
        }

        public Genders Gender { get; set; }

        public int Age => _age;

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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("_birthDate", _birthDate);
            info.AddValue("Gender", Gender);
        }

        public void OnDeserialization(object sender)
        {
            CalculateAge();
        }

        public override string ToString()
        {
            return $"Name = {Name}, BirthDate = {_birthDate:yyyy-MM-dd}, Gender = {Gender}, Age = {_age}";
        }

        private void CalculateAge()
        {
            var now = int.Parse(_currentDate.ToString("yyyyMMdd"));
            var born = int.Parse(_birthDate.ToString("yyyyMMdd"));

            _age = (now - born) / 10000;
        }
    }
}
