using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Pesho", 10, 50);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expName = "Pesho";
            int expDamage = 10;
            int expHP = 50;

            Assert.IsNotNull(this.warrior);
            Assert.AreEqual(expName, this.warrior.Name);
            Assert.AreEqual(expDamage, this.warrior.Damage);
            Assert.AreEqual(expHP, this.warrior.HP);

        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("         ")]
        public void NameSetterShouldThrowExceptionWithInvalidValue(string name)
        {
            int dmg = 10;
            int hp = 20;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);

            }, "Name should not be empty or whitespace!");
        }


        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void DamageSetterShouldThrowExceptionWithZeroOrNegativeValue(int damage)
        {
            string name = "Gosho";
            int hp = 20;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);

            }, "Damage value should be positive!");
        }


        [Test]
        public void HPSetterShouldThrowExceptionWithNegativeValue()
        {
            string name = "Gosho";
            int damage = 10;
            int hp = -10;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);

            }, "HP should not be negative!");
        }

        [Test]
        [TestCase(MIN_ATTACK_HP)]
        [TestCase(MIN_ATTACK_HP - 10)]
        public void AttackingWithLowHpShouldThrowException(int attackerHp)
        {
            string attackerName = "Attacker";
            int attackerDmg = 20;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHp);

            string defenderName = "Defender";
            int defenderDmg = 10;
            int defenderHp = 50;

            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);

            }, "Your HP is too low in order to attack other warriors!");

        }

        [Test]
        [TestCase(MIN_ATTACK_HP)]
        [TestCase(MIN_ATTACK_HP - 10)]
        public void AttackingEnemyWithLowHpShouldThrowException(int defenderHp)
        {
            string attackerName = "Attacker";
            int attackerDmg = 20;
            int attackerHp = 50;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHp);

            string defenderName = "Defender";
            int defenderDmg = 10;


            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);

            }, $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");

        }

        [Test]
        public void AttackingTooStrongEnemyShouldThrowException()
        {
            string attackerName = "Attacker";
            int attackerDmg = 20;
            int attackerHp = 50;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHp);

            string defenderName = "Defender";
            int defenderDmg = 60;
            int defenderHp = 50;

            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);

            }, $"You are trying to attack too strong enemy");

        }

        [Test]
        public void AttackingEnemyShouldDecreaseAttackerHP()
        {
            Warrior enemy = new Warrior("Gosho", 10, 50);

            int expHp = 40;

            this.warrior.Attack(enemy);

            Assert.AreEqual(expHp, warrior.HP);
        }

        [Test]
        public void AttackingEnemyShouldDecreaseEnemyHP()
        {
            Warrior enemy = new Warrior("Gosho", 10, 50);

            int expHp = 40;

            this.warrior.Attack(enemy);

            Assert.AreEqual(expHp, enemy.HP);
        }

        [Test]
        public void AttackingEnemyShouldSetEnemyHpToZeroIfDead()
        {
            this.warrior = new Warrior("Pehso", 55, 50);
            Warrior enemy = new Warrior("Gosho", 10, 50);

            int expEnemyHp = 0;

            this.warrior.Attack(enemy);

            Assert.AreEqual(expEnemyHp, enemy.HP);
        }

    }
}