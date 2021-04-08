using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Cars => this.cars.AsReadOnly();

        public void Add(ICar model)
        {
            this.cars.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.cars;
        }

        public ICar GetByName(string name)
        {
            ICar car = cars.FirstOrDefault(x => x.Model == name);

            return car;
        }

        public bool Remove(ICar model)
        {
            return cars.Remove(model);
        }
    }
}
