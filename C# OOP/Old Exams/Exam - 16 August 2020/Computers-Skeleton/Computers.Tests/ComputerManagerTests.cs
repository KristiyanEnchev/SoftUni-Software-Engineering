using NUnit.Framework;
using System.Collections.Generic;
using System;
namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager manager;
        private Computer computer1;
        private Computer computer2;

        [SetUp]
        public void Setup()
        {
            computer1 = new Computer("Acer", "aspire", -5);
            manager = new ComputerManager();
            computer2 = new Computer("IBM", "pravec", 250);
        }

        [Test]
        public void Check_Prop_Setters()
        {
            Assert.AreEqual(computer1.Manufacturer, "Acer");
            Assert.AreEqual(computer1.Model, "aspire");
            Assert.AreEqual(computer1.Price, -5);
        }

        [Test]
        public void Check_Ctor_Setters()
        {
            //Assert.AreEqual(manager.Computers, string.Empty);
            var comp = new List<Computer>{computer2};
            manager.AddComputer(computer2);
            Assert.AreEqual(manager.Computers, comp);
        }

        [Test]
        public void Chech_CountProperty_WorksCorectly()
        {
            manager.AddComputer(computer2);
            Assert.AreEqual(manager.Count, 1);
        }

        [Test]
        public void AddComputer_ChouldThrowExeption_WhenManufacterurAndModelExists()
        {
            manager.AddComputer(computer2);
            computer1 = new Computer("IBM", "pravec", 100);

            Assert.Throws<ArgumentException>(() =>
            {
                manager.AddComputer(computer1);
            });
        }

        [Test]
        public void GetComputer_ShouldThrowExeption_WhenComputerIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                manager.GetComputer(computer1.Manufacturer, computer1.Model);
            });
        }

        [Test]
        public void GetComputersByManufacturer_ShouldReturnCollectionOfComputersWithSameManufacterur()
        {
            List<Computer> computers = new List<Computer>();
            computers.Add(computer1);

            manager.AddComputer(computer1);
            manager.AddComputer(computer2);
            var compManager = manager.GetComputersByManufacturer("Acer");

            Assert.AreEqual(compManager, computers);
        }


        [Test]
        public void RemoveComputer_ShouldThrowExeption_WhenComputerIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                manager.RemoveComputer(computer1.Manufacturer, computer1.Model);
            });
        }

        [Test]
        public void RemoveComputer_SholdDecreaseCount()
        {
            int expectedCount = 1;
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);
            manager.RemoveComputer(computer2.Manufacturer, computer2.Model);

            Assert.AreEqual(expectedCount, manager.Computers.Count);
        }

        [Test]
        public void Check_PrivateValidator()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                manager.AddComputer(null);
            });
        }

        [Test]
        public void RemoveComputerReturnsTheRemovedOne()
        {
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);
            Assert.AreEqual(computer2, manager.RemoveComputer("IBM", "pravec"));
        }

        [Test]
        public void GetComputer_ShouldThrowExeption()
        {
            computer1 = new Computer(null, null, 20);

            Assert.Throws<ArgumentNullException>(() =>
            {
                manager.GetComputer(computer1.Manufacturer, computer1.Model);
            });
        }
    }
}