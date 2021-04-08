using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EasterRaces.Models.Races.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Races => this.races.AsReadOnly();

        public void Add(IRace model)
        {
             this.races.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.races;
        }

        public IRace GetByName(string name)
        {
            IRace race = races.FirstOrDefault(x => x.Name == name);

            return race;
        }

        public bool Remove(IRace model)
        {
            return races.Remove(model);
        }
    }
}
