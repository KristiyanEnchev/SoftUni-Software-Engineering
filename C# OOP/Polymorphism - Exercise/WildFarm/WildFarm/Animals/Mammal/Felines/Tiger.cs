using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammal.Felines
{
    public class Tiger : Feline
    {
        private const double BaseWeightModifier = 1;

        private static HashSet<string> OwlAllowedFoods = new HashSet<string>
        {
            nameof(Meat),
        };

        public Tiger(string name, double weight, string livingRegiuon, string breed)
       : base(name, weight, OwlAllowedFoods, BaseWeightModifier, livingRegiuon, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
