using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
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
            this.drivers = new List<IDriver>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    string excMessage = String.Format(ExceptionMessages.InvalidName, value, 5);
                    throw new ArgumentException(excMessage);
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get
            {
                return this.laps;
            }
            private set
            {
                if (value < 1)
                {
                    string excMessage = String.Format(ExceptionMessages.InvalidNumberOfLaps, 1);
                    throw new ArgumentException(excMessage);
                }

                this.laps = value;
            }
        }


        public IReadOnlyCollection<IDriver> Drivers => this.drivers.AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver is null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                string excMessage = String.Format(ExceptionMessages.DriverNotParticipate, driver.Name);
                throw new ArgumentException(excMessage);
            }

            if (this.drivers.Contains(driver))
            {
                throw new ArgumentNullException(ExceptionMessages.DriversExists, Name);
            }

            this.drivers.Add(driver);
        }
    }
}
