using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double BaseWeightModifier = 0.35;
        private static HashSet<string> OwlAllowedFoods = new HashSet<string>
        {
            nameof(Meat),
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Seeds),
        };


        public Hen(string name, double weight, double wingSize)
               : base(name, weight,OwlAllowedFoods, BaseWeightModifier, wingSize)
        {

        }

        public override string ProduceSound()
        {
            return "Cluck";

        }
    }
}
