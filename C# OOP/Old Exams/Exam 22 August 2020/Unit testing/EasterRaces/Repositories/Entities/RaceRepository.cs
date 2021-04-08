using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public void Add(IRace name)
        {
            races.Add(name);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return races;
        }

        public IRace GetByName(string name)
        {
            return races.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IRace name)
        {
            return races.Remove(name);
        }
    }
}
