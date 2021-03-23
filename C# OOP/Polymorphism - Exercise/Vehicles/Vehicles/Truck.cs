using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicles
    {
        private const double TruckAirConditioner = 1.6;

        public Truck(double fule, double fuelConsumption)
              : base(fule, fuelConsumption, TruckAirConditioner)
        {

        }

        public override void Refuel(double amount)
        {
            base.Refuel(amount * 0.95);
        }
    }
}
