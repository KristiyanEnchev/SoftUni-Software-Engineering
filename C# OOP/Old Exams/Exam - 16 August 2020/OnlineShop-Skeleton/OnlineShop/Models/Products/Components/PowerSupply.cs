using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class PowerSupply : Component
    {
        //private const double powerSupplyModifier = 1.05;

        public PowerSupply(int id, string manufacturer, string model, decimal price, double overallPerformance, int component)
            : base(id, manufacturer, model, price, overallPerformance, component)
        {
        }

        public override double OverallPerformance => base.OverallPerformance * 1.05;
    }
}
