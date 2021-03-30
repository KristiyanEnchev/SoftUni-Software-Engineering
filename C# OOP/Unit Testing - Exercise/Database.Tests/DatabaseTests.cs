using NUnit.Framework;
using System;


namespace Tests
{
    [TestFixture]

    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database(2, 3, 4, 5, 6);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int expectedCount = 5;
            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void When_CommandAdd_ShoulAddElemnetToTheEndOfTheCollection()
        {
            int element = 10;
            database.Add(element);
            int[] feched = database.Fetch();

            Assert.AreEqual(element, feched[feched.Length - 1]);
        }

        [Test]
        public void When_Add_ShouldIncreaseCount()
        {
            int expectedCount = 6;
            database.Add(10);

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void When_Full_ShouldThrowExeption()
        {
            for (int i = 0; i < 11; i++)
            {
                database.Add(i);
            }

            Assert.That(() =>
            {
                database.Add(15);

            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void When_Remove_ShouldDecreaseCount()
        {
            int expectedCount = 4;
            database.Remove();

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void When_CollectionIsEmpty_ShouldThrowExeption()
        {
            for (int i = 0; i < 5; i++)
            {
                database.Remove();
            }

            Assert.That(() =>
            {
                database.Remove();
            }, Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void When_Feche_ShouldReternArray()
        {
            int[] expectedArray = new int[] { 2, 3, 4, 5, 6 };
            int[] array = database.Fetch();

            CollectionAssert.AreEqual(expectedArray, array);
        }
    }
}