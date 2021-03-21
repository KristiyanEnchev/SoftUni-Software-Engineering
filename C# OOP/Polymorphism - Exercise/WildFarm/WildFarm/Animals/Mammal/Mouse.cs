using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammal
{
    public class Mouse : Mammal
    {
        private const double BaseWeightModifier = 0.1;

        private static HashSet<string> OwlAllowedFoods = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Fruit),
        };

        public Mouse(string name, double weight, string livingRegiuon)
                : base(name, weight, OwlAllowedFoods, BaseWeightModifier, livingRegiuon)
        {

        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
