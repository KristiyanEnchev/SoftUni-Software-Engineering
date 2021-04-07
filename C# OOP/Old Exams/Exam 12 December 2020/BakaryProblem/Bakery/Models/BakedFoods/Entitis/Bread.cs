using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods.Entitis
{
    public class Bread : BakedFood
    {
        private const int BreadPortion = 200;

        public Bread(string name, decimal price) 
            : base(name, BreadPortion, price)
        {
        }
    }
}
