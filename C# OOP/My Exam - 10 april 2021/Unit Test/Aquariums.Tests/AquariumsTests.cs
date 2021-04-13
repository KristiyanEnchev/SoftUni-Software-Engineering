using NUnit.Framework;
using System.Collections.Generic;

namespace Aquariums.Tests
{
    using System;

    public class AquariumsTests
    {
        private Fish fish;
        private Aquarium aquarium;

        [SetUp]
        public void Setup()
        {
            fish = new Fish("gold");
            aquarium = new Aquarium("atlantis", 200);
        }

        [Test]
        public void Check_Ctor()
        {
            Assert.IsNotNull(this.aquarium);
            Assert.IsNotNull(this.fish);
            Assert.IsNotNull(aquarium.Count);
        }

        [Test]
        public void Check_Prop_Setters()
        {
            Assert.AreEqual(fish.Name, "gold");
            Assert.AreEqual(fish.Available, true);
        }

        [Test]
        [TestCase("", 100)]
        [TestCase(null, 100)]
        //[TestCase("      ",100)]
        public void Prop_ShouldThrowExceptionIfNUllOrWitespace(string name, int capacity)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, capacity);

            });
        }

        [Test]
        public void Prop_Capacity_ShouldThrowExceptionIfNUllOrWitespace()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("gold", -5);

            });
        }

        [Test]
        public void AddFish_ShouldThrowException()
        {
            var aquarium = new Aquarium("atlan", 1);
            var fish2 = new Fish("silver");

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish);
                aquarium.Add(fish2);
            });
        }
        [Test]
        public void AddFish_ShouldIncreaseCount()
        {
            int expectedCount = 2;
            var aquarium = new Aquarium("atlan", 3);
            var fish2 = new Fish("silver");

            aquarium.Add(fish);
            aquarium.Add(fish2);

            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void RemoveFish_ShouldThrowException()
        {
            var aquarium = new Aquarium("atlan", 3);
            var fish2 = new Fish("silver");
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish(fish2.Name);
            });
        }

        [Test]
        public void RemoveFish_ShouldDecreaseCount()
        {
            int expectedCount = 1;
            var aquarium = new Aquarium("atlan", 3);
            var fish2 = new Fish("silver");

            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.RemoveFish(fish.Name);

            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void SellFish_ShouldThrowException()
        {
            var aquarium = new Aquarium("atlan", 3);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("gosho");
            });
        }

        [Test]
        public void SellFish_ShouldSetAvaible()
        {
            var aquarium = new Aquarium("atlan", 3);
            var fish2 = fish;
            aquarium.Add(fish);

            Assert.AreEqual(aquarium.SellFish(fish.Name), fish2);
        }
        [Test]
        public void SellFish_ShouldReturnCorectly()
        {
            bool expectetOutput = false;
            var aquarium = new Aquarium("atlan", 3);

            aquarium.Add(fish);
            aquarium.SellFish(fish.Name);

            Assert.AreEqual(expectetOutput, fish.Available);
        }

        [Test]
        public void Repor_ShouldReturnCorectly() 
        {
            aquarium.Add(fish);
            string expectedOutput = $"Fish available at {aquarium.Name}: {"gold"}";

            Assert.AreEqual(expectedOutput, aquarium.Report());
        }

    }
}
