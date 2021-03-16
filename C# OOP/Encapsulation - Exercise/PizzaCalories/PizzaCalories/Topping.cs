using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int MinGrams = 1;
        private const int MaxGrams = 50;

        private string name;
        private int weight;

        public Topping(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                var valueAsLower = value.ToLower();

                if (valueAsLower != "meat" &&
                    valueAsLower != "veggies" &&
                    valueAsLower != "cheese" &&
                    valueAsLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.name = value;
            }
        }

        public int Weight
        {
            get => this.weight;

            private set
            {
                Validator.ThrowIfNumberIsNotInRange(MinGrams, MaxGrams, value, $"{this.name} weight should be in the range [1..50].");

                this.weight = value;
            }

        }

        public double GetCalories()
        {
            var modifier = GetModifier();

            return this.Weight * 2 * modifier;
        }

        private double GetModifier()
        {
            var nameToLower = this.Name.ToLower();

            if (nameToLower == "meat")
            {
                return 1.2;
            }
            else if (nameToLower == "veggies")
            {
                return 0.8;
            }
            else if (nameToLower == "cheese")
            {
                return 1.1;
            }

            return 0.9;
        }
    }
}
