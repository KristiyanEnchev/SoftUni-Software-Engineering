using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Races.Entities;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly List<ICar> cars;
        private readonly List<IRace> races;
        private readonly List<IDriver> drivers;

        public ChampionshipController()
        {
            this.cars = new List<ICar>();
            this.races = new List<IRace>();
            this.drivers = new List<IDriver>();
        }

        public string CreateDriver(string driverName)
        {
            if (drivers.Any(x => x.Name == driverName))
            {
                string exMassage = string.Format(ExceptionMessages.DriversExists, driverName);
                throw new AggregateException(exMassage);
            }

            IDriver driver = new Driver(driverName);
            drivers.Add(driver);

            string massage = string.Format(OutputMessages.DriverCreated, driverName);
            return massage;
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (cars.Any(x => x.Model == model))
            {
                string massage = string.Format(ExceptionMessages.CarExists, model);
                throw new ArgumentException(massage);
            }

            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }

            if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            this.cars.Add(car);

            return string.Format(OutputMessages.CarCreated, type, model);
        }


        public string CreateRace(string name, int laps)
        {
            if (races.Any(x => x.Name == name))
            {
                string massage = string.Format(ExceptionMessages.RaceExists, name);
                throw new InvalidOperationException(massage);
            }

            IRace race = new Race(name, laps);
            races.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (!drivers.Any(x => x.Name == driverName))
            {
                string massage = string.Format(ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(massage);
            }

            if (!cars.Any(x => x.Model == carModel))
            {
                string massage = string.Format(ExceptionMessages.CarNotFound, carModel);
                throw new InvalidOperationException(massage);
            }

            IDriver driver = this.drivers.FirstOrDefault(x => x.Name == driverName);
            ICar car = this.cars.FirstOrDefault(x => x.Model == carModel);

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (! races.Any(x => x.Name == raceName))
            {
                string massage = string.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(massage);
            }

            if (! drivers.Any(x => x.Name == driverName))
            {
                string massage = string.Format(ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(massage);
            }

            IRace race = races.FirstOrDefault(x => x.Name == raceName);
            IDriver driver = drivers.FirstOrDefault(x => x.Name == driverName);

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }


        public string StartRace(string raceName)
        {
            if (!races.Any(x => x.Name == raceName))
            {
                string massage = string.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(massage);
            }

            IRace race = races.FirstOrDefault(x => x.Name == raceName);

            if (this.drivers.Count < 3)
            {
                string massage = string.Format(ExceptionMessages.RaceInvalid, raceName, 3);
                throw new InvalidOperationException(massage);
            }

            List<IDriver> drivers = race
               .Drivers
               .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
               .Take(3)
               .ToList();

            IDriver first = drivers[0];
            IDriver second = drivers[1];
            IDriver thurd = drivers[2];

            races.Remove(race);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, first.Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, second.Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, thurd.Name, race.Name));

            return sb.ToString().TrimEnd();
        }
    }
}
