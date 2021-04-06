using System;
using System.Collections.Generic;
using System.Text;

namespace P04Recharge
{
    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {
        }

        public override void Sleep()
        {
            // sleep...
        }

        public override void Recharge()
        {
            throw new InvalidOperationException("Employees cannot recharge");
        }

    }
}
