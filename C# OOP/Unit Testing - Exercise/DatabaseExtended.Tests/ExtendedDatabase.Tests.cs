using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;
        private Person firstPerson;
        private Person secondPerson;
        [SetUp]
        public void Setup()
        {
            this.firstPerson = new Person(1, "Pesho");
            this.secondPerson = new Person(2, "Gosho");
            this.database = new ExtendedDatabase(firstPerson, secondPerson);
        }

        [Test]
        public void ConstructorShouldThrowExceptionWithMoreElementsThanCapacity()
        {
            Person[] people = new Person[17];

            for (int i = 0; i < 17; i++)
            {
                people[i] = new Person(i + 1, "Pesho" + i);
            }

            Assert.That(() =>
            {
                this.database = new ExtendedDatabase(people);

            }, Throws.ArgumentException.With.Message
                    .EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {

            int expCount = 2;

            Assert.AreEqual(expCount, this.database.Count);

        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            Person person = new Person(3, "Misho");
            int expCount = 3;

            this.database.Add(person);

            Assert.AreEqual(expCount, this.database.Count);
        }

        [Test]
        public void AddShouldThrowExceptionIfFullCapacity()
        {
            for (int i = 0; i < 14; i++)
            {
                Person person = new Person(i + 3, $"Test{i + 1}");
                this.database.Add(person);
            }

            Assert.That(() =>
            {
                this.database.Add(new Person(111, "Pesho111"));

            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddShouldThrowExceptionIfPersonUsernameExists()
        {
            Person person = new Person(10, "Pesho");

            Assert.That(() =>
            {
                this.database.Add(person);

            }, Throws.InvalidOperationException.With.Message
                        .EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddShouldThrowExceptionIfPersonIdExists()
        {
            Person person = new Person(1, "Test");

            Assert.That(() =>
            {
                this.database.Add(person);

            }, Throws.InvalidOperationException.With.Message
                        .EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void RemoveShouldDecreaseCount()
        {
            int expCount = 1;

            this.database.Remove();

            Assert.AreEqual(expCount, this.database.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionWithIfEmpty()
        {
            this.database.Remove();
            this.database.Remove();

            Assert.That(() =>
            {
                this.database.Remove();

            }, Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameShouldReturnCorrectPerson()
        {
            var returnedPerson = this.database.FindByUsername("Pesho");

            Assert.AreEqual(this.firstPerson, returnedPerson);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameShouldThrowExceptionWithInvalidUsername(string username)
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.database.FindByUsername(username);

            }, "Username parameter is null!");
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWithNonExistingPerson()
        {
            string username = "Test";

            Assert.That(() =>
            {
                this.database.FindByUsername(username);

            }, Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByIdShouldReturnCorrectPerson()
        {
            Person person = this.database.FindById(1);

            Assert.AreEqual(this.firstPerson, person);
        }

        [Test]
        public void FindByIdShouldThrowExceptionWithNegativeId()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.database.FindById(-1);

            }, "Id should be a positive number!");
        }

        [Test]
        public void FindByIdShouldThrowExceptionWithNonExistingId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindById(5);

            }, "No user is present by this ID!");
        }
    }
}