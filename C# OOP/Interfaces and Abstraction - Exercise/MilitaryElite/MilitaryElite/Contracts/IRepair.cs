using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface IRepair
    {
        string PartName { get; }

        int HourWorked { get; }
    }
}
