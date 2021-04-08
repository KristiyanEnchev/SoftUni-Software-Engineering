using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int MuscleCarMinHorsePowerModifier = 400;
        private const int MuscleCarMaxHorsePowerModifier = 600;
        private const double MuscleCarCubicsuntimetersModifier = 5000;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, MuscleCarCubicsuntimetersModifier, MuscleCarMinHorsePowerModifier, MuscleCarMaxHorsePowerModifier)
        {
            
        }
    }
}
