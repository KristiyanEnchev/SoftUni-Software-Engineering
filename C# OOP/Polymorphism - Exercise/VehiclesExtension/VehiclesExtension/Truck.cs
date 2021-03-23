using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicles
    {
        private const double TruckAirConditioner = 1.6;

        public Truck(double fuel, double fuelConsumption, double tankCapacity)
              : base(fuel, fuelConsumption, TruckAirConditioner, tankCapacity)
        {

        }

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (this.Fuel + amount > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount } fuel in the tank");
            }
            this.Fuel += amount * 0.95;
        }
    }
}
