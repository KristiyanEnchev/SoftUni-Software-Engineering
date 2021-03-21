using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammal.Felines
{
    public class Cat : Feline
    {
        private const double BaseWeightModifier = 0.3;

        private static HashSet<string> OwlAllowedFoods = new HashSet<string>
        {
            nameof(Meat),
            nameof(Vegetable),
        };

        public Cat(string name, double weight, string livingRegiuon, string breed)
       : base(name, weight, OwlAllowedFoods, BaseWeightModifier, livingRegiuon, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
