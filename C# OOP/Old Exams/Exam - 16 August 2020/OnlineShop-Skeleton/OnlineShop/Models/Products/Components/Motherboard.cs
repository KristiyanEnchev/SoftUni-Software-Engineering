using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class Motherboard : Component
    {
        //private const double motherboardModifier = 1.25;

        public Motherboard(int id, string manufacturer, string model, decimal price, double overallPerformance, int component)
            : base(id, manufacturer, model, price, overallPerformance, component)
        {
        }

        public override double OverallPerformance => base.OverallPerformance * 1.25;
    }
}
