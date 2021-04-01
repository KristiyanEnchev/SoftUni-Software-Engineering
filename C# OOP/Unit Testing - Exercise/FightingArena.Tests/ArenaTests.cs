using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior attacker;
        private Warrior defender;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.attacker = new Warrior("Pesho", 20, 50);
            this.defender = new Warrior("Gosho", 20, 50);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.arena);
            Assert.IsNotNull(this.arena.Warriors);
            Assert.AreEqual(0, this.arena.Count);

        }

        [Test]
        public void EnrolShouldIncreaseCount()
        {
            Warrior warrior = new Warrior("Pesho", 10, 50);

            this.arena.Enroll(warrior);

            int expCount = 1;

            Assert.AreEqual(expCount, this.arena.Count);
        }

        [Test]
        public void EnrolShouldThrowExceptionWithExistingWarriorName()
        {
            Warrior warriorOne = new Warrior("Pesho", 10, 50);
            Warrior warriorTwo = new Warrior("Pesho", 20, 50);

            this.arena.Enroll(warriorOne);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warriorTwo);

            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        [TestCase("Pesho", null)]
        [TestCase(null, "Pesho")]
        public void FightShouldThrowExceptionWithNonExistingAttackerOrDeffender(string attName, string defName)
        {
            this.arena.Enroll(this.attacker);

            Warrior attWarrior = this.arena.Warriors.FirstOrDefault(x => x.Name == attName);
            Warrior defWarrior = this.arena.Warriors.FirstOrDefault(x => x.Name == defName);

            string missingName = attName == null ? attName : defName;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(attName, defName);

            }, $"There is no fighter with name {missingName} enrolled for the fights!");


        }

        [Test]
        public void FightShouldWorkCorrectlyWithExistingAttackerAndDefender()
        {
            this.arena.Enroll(this.attacker);
            this.arena.Enroll(this.defender);

            int expAttackerHp = 30;
            int expDefenderHp = 30;

            this.arena.Fight(this.attacker.Name, this.defender.Name);

            Assert.AreEqual(expAttackerHp, this.attacker.HP);
            Assert.AreEqual(expDefenderHp, this.defender.HP);
        }
    }
}