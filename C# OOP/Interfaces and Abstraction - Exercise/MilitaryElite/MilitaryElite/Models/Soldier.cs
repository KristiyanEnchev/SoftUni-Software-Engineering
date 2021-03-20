using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(string id , string firstNam, string lastName)
        {
            this.Id = id;
            this.FirstName = firstNam;
            this.LastNAme = lastName;
        }


        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastNAme { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastNAme} Id: {this.Id}";
        }
    }
}
