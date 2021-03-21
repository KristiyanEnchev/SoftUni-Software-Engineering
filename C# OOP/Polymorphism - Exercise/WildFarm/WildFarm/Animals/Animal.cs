using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight, HashSet<string> allowedFood, double weigthModifier)
        {
            Name = name;
            Weight = weight;
            AllowedFood = allowedFood;
            WeigthModifier = weigthModifier;
        }

        private HashSet<string> AllowedFood { get; set; }

        private double WeigthModifier { get; set; }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            string foodTypeName = food.GetType().Name;

            if (!AllowedFood.Contains(food.GetType().Name))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {foodTypeName}!");
            }

            this.FoodEaten += food.Quantity;

            this.Weight += this.WeigthModifier * food.Quantity;
        }
    }
}
