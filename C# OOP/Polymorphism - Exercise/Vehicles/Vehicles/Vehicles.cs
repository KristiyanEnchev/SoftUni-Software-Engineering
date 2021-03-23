using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicles
    {
        protected Vehicles(double fule, double fuelConsumption, double airConditinerModifire)
        {
            this.Fuel = fule;
            this.FuelConsumption = fuelConsumption;
            this.AirConditionerModifire = airConditinerModifire;
        }

        private double AirConditionerModifire { get; set; }

        public double Fuel { get; private set; }
        public double FuelConsumption { get; private set; }


        public void Drive(double distance)
        {
            double requaredFuel = this.FuelConsumption * distance + distance * this.AirConditionerModifire;

            if (requaredFuel > this.Fuel)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            this.Fuel -= requaredFuel;
        }

        public virtual void Refuel(double amount)
        {
            this.Fuel += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Fuel:f2}";
        }
    }
}
