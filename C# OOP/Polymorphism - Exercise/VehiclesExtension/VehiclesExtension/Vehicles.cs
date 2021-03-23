using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicles
    {
        private double fuel;

        protected Vehicles(double fuel, double fuelConsumption, double airConditinerModifire, double tankCapacity)
        {
            this.fuel = fuel;
            this.FuelConsumption = fuelConsumption;
            this.AirConditionerModifire = airConditinerModifire;
            this.TankCapacity = tankCapacity;
        }

        protected double AirConditionerModifire { get; set; }

        public double Fuel
        {
            get => this.fuel;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuel = 0;
                }
                else
                {
                    this.fuel = value;
                }
            }
        }
        public double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }


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
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.Fuel + amount > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            this.Fuel += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Fuel:f2}";
        }
    }
}
