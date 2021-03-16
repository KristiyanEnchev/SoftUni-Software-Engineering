using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MaxToppings = 10;
        private const int MinNameLenght = 1;
        private const int MaxNameLenght = 15;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < MinNameLenght || value.Length > MaxNameLenght)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == MaxToppings)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        public double GetCalories()
        {
            return this.dough.GetCalories() + this.toppings.Sum(t => t.GetCalories());
        }
    }
}
