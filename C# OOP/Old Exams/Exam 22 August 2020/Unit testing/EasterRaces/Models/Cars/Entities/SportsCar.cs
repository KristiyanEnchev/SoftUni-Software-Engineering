using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const int SportsCarMinHorsePowerModifier = 250;
        private const int SportsCarMaxHorsePowerModifier = 450;
        private const double SportsCarCubicsuntimetersModifier = 3000;


        public SportsCar(string model, int horsePower) 
            : base(model, horsePower, SportsCarCubicsuntimetersModifier, SportsCarMinHorsePowerModifier, SportsCarMaxHorsePowerModifier)
        {
        }
    }
}
