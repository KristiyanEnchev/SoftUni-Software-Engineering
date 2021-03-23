using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicles
    {
        private const double BussAirConditioner = 1.4;
        public Bus(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption, BussAirConditioner, tankCapacity)
        {

        }

        public void TurnOnAirConditioner()
        {
            this.AirConditionerModifire = BussAirConditioner;
        }

        public void TurnOffAirCondition()
        {
            this.AirConditionerModifire = 0;

        }
    }
}
