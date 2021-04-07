using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks.Entitis
{
    public class Water : Drink
    {
        public Water(string name, int portion, string brand)
            : base(name, portion, 1.50m, brand)
        {
        }
    }
}
