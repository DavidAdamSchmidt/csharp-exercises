using System;
using System.IO;
using NUnit.Framework;

namespace SerializePeople.UnitTests
{
    public class PersonTests
    {
        private const string FileName = "test.bin";
        private Person _person;

        [SetUp]
        public void CreatePerson()
        {
            _person = new Person(new DateTime(2019, 11, 8))
            {
                Name = "Erwin",
                Gender = Person.Genders.Male
            };
        }

        [Test]
        public void ObjectCreation_SetProperValues_ToStringShouldWorkProperly()
        {
            _person.BirthDate = new DateTime(1978, 1, 1);

            const string expected = "Name = Erwin, BirthDate = 1978-01-01, Gender = Male, Age = 41";

            Assert.AreEqual(expected, _person.ToString());
        }

        [Test]
        public void Age_CurrentDateIs20191108BirthDateIs19191108_AgeShouldBe100()
        {
            _person.BirthDate = new DateTime(1919, 11, 8);

            Assert.AreEqual(100, _person.Age);
        }

        [Test]
        public void Age_CurrentDateIs20191108BirthDateIs19191109_AgeShouldBe99()
        {
            _person.BirthDate = new DateTime(1919, 11, 9);

            Assert.AreEqual(99, _person.Age);
        }

        [Test]
        public void Serialize_SerializeObject_FileShouldBeCreated()
        {
            SerializeObject();

            Assert.True(File.Exists(FileName));
        }

        [Test]
        public void Deserialize_DeserializeObject_ObjectShouldBeCreated()
        {
            SerializeObject();

            var deserialized = Person.Deserialize(FileName);

            Assert.AreEqual(_person.ToString(), deserialized.ToString());
        }

        private void SerializeObject()
        {
            _person.BirthDate = new DateTime(1978, 1, 1);
            File.Delete(FileName);

            _person.Serialize(FileName);
        }
    }
}
