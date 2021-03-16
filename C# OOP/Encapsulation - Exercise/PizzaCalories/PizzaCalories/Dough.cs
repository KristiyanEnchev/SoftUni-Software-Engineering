using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int MinGrams = 1;
        private const int MaxGrams = 200;

        private const string InvalidDoughExeption = "Invalid type of dough.";

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnik, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnik;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;

            private set
            {
                var valuAsLower = value.ToLower();

                if (valuAsLower != "white" && valuAsLower != "wholegrain")
                {
                    throw new ArgumentException(InvalidDoughExeption);
                }

                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;

            private set
            {
                var valuAsLower = value.ToLower();

                if (valuAsLower != "crispy" &&
                    valuAsLower != "chewy" &&
                    valuAsLower != "homemade")
                {
                    throw new ArgumentException(InvalidDoughExeption);
                }

                this.bakingTechnique = value;
            }
        }
        public int Weight
        {
            get => this.weight;

            private set
            {
                Validator.ThrowIfNumberIsNotInRange(MinGrams, MaxGrams, value, "Dough weight should be in the range [1..200].");

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            var flourTypeModifier = GetFlouerTypeModifier();

            var bakingTechniqueModifier = GetBakingTechniqueModifier();

            return this.Weight * 2 * flourTypeModifier * bakingTechniqueModifier;
        }

        private double GetBakingTechniqueModifier()
        {
            var techniqueToLower = this.bakingTechnique.ToLower();

            if (techniqueToLower == "crispy")
            {
                return 0.9;
            }
            else if (techniqueToLower == "chewy")
            {
                return 1.1;
            }

            return 1;
        }

        private double GetFlouerTypeModifier()
        {
            var flourTypeToLower = this.flourType.ToLower();

            if (flourTypeToLower == "white")
            {
                return 1.5;
            }

            return 1;
        }
    }
}
