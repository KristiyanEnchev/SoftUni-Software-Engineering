using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Toyota", "Avensis", 10, 100);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            double expFuelAmount = 0;
            string expMake = "Toyota";
            string expModel = "Avensis";
            double expFuelConsumption = 10;
            double expFuelCapacity = 100;

            Car car = new Car(expMake, expModel, expFuelConsumption, expFuelCapacity);

            Assert.AreEqual(expFuelAmount, car.FuelAmount);
            Assert.AreEqual(expMake, car.Make);
            Assert.AreEqual(expModel, car.Model);
            Assert.AreEqual(expFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expFuelCapacity, car.FuelCapacity);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void MakeSetterShouldThrowExceptionWithInvalidMake(string make)
        {
            string model = "Avensis";
            double fuelConsumption = 10;
            double fuelCapacity = 100;
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Make cannot be null or empty!");

        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ModelSetterShouldThrowExceptionWithInvalidModel(string model)
        {
            string make = "Toyota";
            double fuelConsumption = 10;
            double fuelCapacity = 100;
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Model cannot be null or empty!");

        }

        [Test]
        [TestCase(0)]
        [TestCase(-6)]
        public void FuelConsumptionSetterShouldThrowExceptionWithZeroOrNegativeValue(double fuelConsumption)
        {
            string make = "Toyota";
            string model = "Avensis";
            double fuelCapacity = 100;
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Fuel consumption cannot be zero or negative!");

        }

        [Test]
        [TestCase(0)]
        [TestCase(-100)]
        public void FuelCapacitySetterShouldThrowExceptionWithZeroOrNegativeValue(double fuelCapacity)
        {
            string make = "Toyota";
            string model = "Avensis";
            double fuelConsumption = 10;
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Fuel capacity cannot be zero or negative!");

        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void RefuelShouldThrowExceptionWithZeroOrNegativeFuel(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(fuelToRefuel);

            }, "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void RefuelShouldIncreaseFuelAmount()
        {
            double expFuelAmount = 10;

            this.car.Refuel(10);

            Assert.AreEqual(expFuelAmount, this.car.FuelAmount);
        }

        [Test]
        public void RefuelWithMoreFuelThanCapacityShouldSetFuelAmountToMaxCapacity()
        {
            double fuelToRefuel = 110;

            this.car.Refuel(fuelToRefuel);
            double expFuelAmount = 100;

            Assert.AreEqual(expFuelAmount, this.car.FuelAmount);
        }

        [Test]
        public void DriveShouldReduceFuelAmount()
        {
            double distance = 50;
            double fuelNeeded = (distance / 100) * this.car.FuelConsumption;
            this.car.Refuel(50);
            double expFuelAmount = 45;

            this.car.Drive(distance);

            Assert.AreEqual(expFuelAmount, this.car.FuelAmount);

        }
        [Test]
        public void DriveShouldThrowExceptionWithNotEnoughFuelAmount()
        {
            double distance = 50;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.car.Drive(distance);

            }, "You don't have enough fuel to drive!");
        }
    }
}