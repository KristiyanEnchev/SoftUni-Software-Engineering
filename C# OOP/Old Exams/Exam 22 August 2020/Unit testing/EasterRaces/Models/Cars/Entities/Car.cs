using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Contracts
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.MinHorsePower = minHorsePower;
            this.MaxHorsePower = maxHorsePower;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }


        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    string massage = String.Format(ExceptionMessages.InvalidModel, Model, 4);
                    throw new ArgumentException(massage);
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                if (value < this.MinHorsePower || value > this.MaxHorsePower )
                {
                    string massage = String.Format(ExceptionMessages.InvalidHorsePower, HorsePower);
                    throw new ArgumentException(massage);
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; }

        public int MinHorsePower { get; }

        public int MaxHorsePower { get; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
