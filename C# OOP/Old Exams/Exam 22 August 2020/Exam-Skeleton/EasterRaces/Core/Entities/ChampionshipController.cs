using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
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
        private const int minPaticipants = 3;
        private List<ICar> cars;
        private List<IRace> races;
        private List<IDriver> drivers;

        public ChampionshipController()
        {
            cars = new List<ICar>();
            races = new List<IRace>();
            drivers = new List<IDriver>();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (!drivers.Any(x => x.Name == driverName))
            {
                string exeption = string.Format(ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(exeption);
            }

            if (!cars.Any(x => x.Model == carModel))
            {
                string exeption = string.Format(ExceptionMessages.CarNotFound, carModel);
                throw new InvalidOperationException(exeption);
            }

            IDriver driver = this.drivers.FirstOrDefault(x =>x.Name == driverName);
            ICar car = this.cars.FirstOrDefault(x => x.Model == carModel);

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (!races.Any(x => x.Name == raceName))
            {
                string exeption = string.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(exeption);
            }

            if (!drivers.Any(x => x.Name == driverName))
            {
                string exeption = string.Format(ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(exeption);
            }

            IDriver driver = drivers.FirstOrDefault(x => x.Name == driverName);
            IRace race = races.FirstOrDefault(x => x.Name == raceName);
            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (cars.Any(x => x.Model == model))
            {
                string exeption = string.Format(ExceptionMessages.CarExists, model);
                throw new ArgumentException(exeption);
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

            cars.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name ,car.Model);
        }

        public string CreateDriver(string driverName)
        {
            if (drivers.Any(x => x.Name == driverName))
            {
                string exeption = string.Format(ExceptionMessages.DriversExists, driverName);
                throw new ArgumentException(exeption);
            }


            IDriver driver = new Driver(driverName);
            this.drivers.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driver.Name);
        }

        public string CreateRace(string name, int laps)
        {
            if (races.Any(x => x.Name == name))
            {
                string exeption = string.Format(ExceptionMessages.RaceExists, name);
                throw new InvalidOperationException(exeption);
            }

            IRace race = new Race(name, laps);
            races.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            if (!races.Any(x => x.Name == raceName))
            {
                string exeption = string.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(exeption);
            }
            
            IRace race = races.FirstOrDefault(x => x.Name == raceName);

            if (race.Drivers.Count < minPaticipants)
            {
                string exeption = string.Format(ExceptionMessages.RaceInvalid, raceName, minPaticipants);
                throw new InvalidOperationException(exeption);
            }

            List<IDriver> drivers = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();

            races.Remove(race);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, drivers[0].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, drivers[1].Name, race.Name));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, drivers[2].Name, race.Name));

            return sb.ToString().TrimEnd();
        }
    }
}
