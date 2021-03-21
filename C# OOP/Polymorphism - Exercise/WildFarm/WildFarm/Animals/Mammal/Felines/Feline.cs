using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammal.Felines
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight, HashSet<string> allowedFood, double weigthModifier, string livingRegiuon, string breed)
               : base(name, weight, allowedFood, weigthModifier, livingRegiuon)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {Breed}, {this.Weight}, {this.Livingregion}, {this.FoodEaten}]";
        }
    }
}
