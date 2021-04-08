using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double sportsCarCubicCentimeters = 3000;
        private const int sportsCarMinHorsePower = 250;
        private const int sportsCarMaxHorsePower = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, sportsCarCubicCentimeters, sportsCarMinHorsePower, sportsCarMaxHorsePower)
        {
        }
    }
}
