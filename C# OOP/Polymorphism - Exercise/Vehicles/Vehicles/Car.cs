using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicles
    {
        private const double CarAirConditioner = 0.9;

        public Car(double fule, double fuelConsumption) 
            : base ( fule,  fuelConsumption, CarAirConditioner)
        {
        
        }
    }
}
