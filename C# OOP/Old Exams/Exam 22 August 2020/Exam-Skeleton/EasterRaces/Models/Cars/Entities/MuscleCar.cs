using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double muscleCarCubicCentimeters = 5000;
        private const int muscleCarMinHorsePower = 400;
        private const int muscleCarMaxHorsePower = 600;

        public MuscleCar(string model, int horsePower)
            : base(model, horsePower , muscleCarCubicCentimeters, muscleCarMinHorsePower, muscleCarMaxHorsePower)
        {
        }
    }
}
