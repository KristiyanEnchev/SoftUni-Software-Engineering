using NUnit.Framework;
using TheRace;
using System;

namespace TheRace.Tests
{
    [TestFixture]

    public class RaceEntryTests
    {
        private RaceEntry race;
        private UnitCar car;
        private UnitDriver driver;


        [SetUp]
        public void Setup()
        {
            car = new UnitCar("opel", 150, 200);
            driver = new UnitDriver("gosho", car);
            race = new RaceEntry();
        }

        [Test]
        public void CheckIFCtorWorksCorectly()
        {
            Assert.IsNotNull(this.race);
            Assert.IsNotNull(this.race.Counter);
        }

        [Test]
        public void AddDriver_Should_ThrowExeptionWhenDriverIsNull()
        {
            UnitDriver driver = null;

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(driver);
            }, "Driver cannot be null.");
        }

        [Test]
        public void AddDriver_ShouldThrowExeption_WhenDriverAlreadyExists()
        {
            UnitDriver driver = new UnitDriver("Gosho", car);

            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(driver);
            }, $"Driver {driver.Name} is already added.");
        }

        [Test]
        public void AddDriver_Should_ReturnMassage_WhenDriverIsAdded()
        {
            string expectedMassage = "Driver gosho added in race.";

            Assert.AreEqual(expectedMassage, race.AddDriver(driver));
        }

        [Test]
        public void AddDriver_ShouldIncreaseCount()
        {
            int expectedCount = 2;
            UnitDriver driver1 = new UnitDriver("Pesho", car);
            race.AddDriver(driver);
            race.AddDriver(driver1);

            Assert.AreEqual(expectedCount, race.Counter);
        }

        [Test]
        public void CalculateAvarageHorsePower_ShouldThrowExeption_WhenThereIsLessThanConstantDrivers()
        {
            int minumumParticipants = 2;
            UnitDriver driver1 = new UnitDriver("Pesho", car);
            race.AddDriver(driver1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.CalculateAverageHorsePower();

            }, $"The race cannot start with less than {minumumParticipants} participants.");
        }

        [Test]
        public void CalculateAvarageHorsePower_ShouldReturnCorrectly()
        {
            UnitDriver driver1 = new UnitDriver("Pesho", car);
            race.AddDriver(driver);
            race.AddDriver(driver1);

            double expectedAvarage = 150;

            double result = race.CalculateAverageHorsePower();

            Assert.AreEqual(expectedAvarage, result);
        }
    }
}