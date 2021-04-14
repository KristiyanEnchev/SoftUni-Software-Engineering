using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            ingredients = new List<Ingredient>();
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel { get { return ingredients.Sum(x => x.Alcohol); } }

        public void Add(Ingredient ingredient)
        {
            if (!ingredients.Any(x => x.Name == ingredient.Name))
            {
                if (ingredients.Count < Capacity && ingredient.Alcohol + CurrentAlcoholLevel <= MaxAlcoholLevel)
                {
                    ingredients.Add(ingredient);
                }
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingrediant = ingredients.FirstOrDefault(p => p.Name == name);

            if (ingrediant == null)
            {
                return false;
            }

            ingredients.Remove(ingrediant);
            return true;
        }

        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredient = ingredients.FirstOrDefault(p => p.Name == name);

            return ingredient;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return ingredients.OrderByDescending(p => p.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingrediant in ingredients)
            {
                sb.AppendLine(ingrediant.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
