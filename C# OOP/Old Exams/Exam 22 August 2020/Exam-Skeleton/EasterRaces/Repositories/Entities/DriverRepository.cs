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
            drivers = new List<IDriver>();
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers.AsReadOnly();

        public void Add(IDriver driver)
        {
            this.drivers.Add(driver);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.drivers;
        }

        public IDriver GetByName(string name)
        {
            IDriver driver = drivers.FirstOrDefault(x => x.Name == name);

            return driver;
        }

        public bool Remove(IDriver driver)
        {
            return drivers.Remove(driver);
        }
    }
}
