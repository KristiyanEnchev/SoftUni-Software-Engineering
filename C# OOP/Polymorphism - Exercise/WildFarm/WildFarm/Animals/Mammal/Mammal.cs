using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammal
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, HashSet<string> allowedFood, double weigthModifier, string livingRegiuon)
    : base(name, weight, allowedFood, weigthModifier)
        {
            this.Livingregion = livingRegiuon;
        }

        public string Livingregion { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.Livingregion}, {this.FoodEaten}]";
        }
    }
}
