using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicles
    {
        private const double CarAirConditioner = 0.9;

        public Car(double fuel, double fuelConsumption, double tankCapacity) 
            : base ( fuel,  fuelConsumption, CarAirConditioner, tankCapacity)
        {
        
        }
    }
}
