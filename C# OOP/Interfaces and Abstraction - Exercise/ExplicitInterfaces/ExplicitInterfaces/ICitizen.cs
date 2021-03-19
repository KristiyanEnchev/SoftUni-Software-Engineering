using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public interface ICitizen : IResident, IPerson
    {
        public string Name { get; }
    }
}
