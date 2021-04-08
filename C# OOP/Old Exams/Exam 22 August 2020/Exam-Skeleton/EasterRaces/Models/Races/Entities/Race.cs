using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private List<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            drivers = new List<IDriver>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Laps cannot be less than 1.");
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers.AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                string exeption = string.Format(ExceptionMessages.DriverInvalid);
                throw new ArgumentNullException(exeption);
            }

            if (driver.CanParticipate == false)
            {
                string exeption = string.Format(ExceptionMessages.DriverNotParticipate, driver.Name);
                throw new ArgumentException(exeption);
            }

            if (drivers.Contains(driver))
            {
                string exeption = string.Format(ExceptionMessages.DriversExists, driver.Name);
                throw new ArgumentNullException(exeption);
            }

            drivers.Add(driver);
        }
    }
}
