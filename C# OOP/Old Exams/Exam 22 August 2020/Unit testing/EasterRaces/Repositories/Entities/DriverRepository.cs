using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> drivers;

        public DriverRepository()
        {
            this.drivers = new List<IDriver>();
        }

        public void Add(IDriver name)
        {
            drivers.Add(name);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return drivers;
        }

        public IDriver GetByName(string name)
        {
            return drivers.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IDriver name)
        {
            return drivers.Remove(name);
        }
    }
}
