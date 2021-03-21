using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammal
{
    public class Dog : Mammal
    {
        private const double BaseWeightModifier = 0.40;

        private static HashSet<string> OwlAllowedFoods = new HashSet<string>
        {
            nameof(Meat),
        };

        public Dog(string name, double weight, string livingRegiuon)
                : base(name, weight, OwlAllowedFoods, BaseWeightModifier, livingRegiuon)
        {

        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
