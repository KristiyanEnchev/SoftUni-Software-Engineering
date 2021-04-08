using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    string massage = String.Format(ExceptionMessages.InvalidName, Name, 5);
                    throw new ArgumentException(massage);
                }

                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get => this.Car != null;
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                string massage = String.Format(ExceptionMessages.CarInvalid, car);
                throw new ArgumentNullException(massage);
            }

            this.Car = car;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
