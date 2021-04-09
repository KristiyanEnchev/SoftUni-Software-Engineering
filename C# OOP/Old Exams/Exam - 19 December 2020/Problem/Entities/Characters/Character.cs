using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.
        private string name;
        //private double baseHealth;
        private double health;
        private double armor;
        //private Bag bag;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                this.name = value;
            }
        }

        public double Health
        {
            get => this.health;
            set
            {
                if (value > BaseHealth)
                {
                    this.health = BaseHealth;
                }
                else if (value < 0)
                {
                    this.health = 0;
                }
                else
                {
                    this.health = value;
                }
            }
        }
        public double BaseHealth { get; private set; }

        public double BaseArmor { get; private set; }

        public double Armor
        {
            get => this.armor;
            private set
            {

                if (value < 0)
                {
                    this.armor = 0;
                }
                else
                {
                    this.armor = value;
                }
            }
        }

        public double AbilityPoints { get; private set; }
        public IBag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            if (hitPoints <= Armor)
            {
                Armor -= hitPoints;
            }
            else
            {
                var pointLeft = hitPoints - Armor;
                Armor = 0;
                Health -= pointLeft;

                if (Health == 0)
                {
                    IsAlive = false;
                }

            }
        }

        public void UseItem(Item item) 
        {
            if (IsAlive)
            {
                item.AffectCharacter(this);
            }
        }
    }
}