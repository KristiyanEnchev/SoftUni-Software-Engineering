using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class SolidStateDrive : Component
    {
        //private const double solidStateDriveModifier = 1.20;

        public SolidStateDrive(int id, string manufacturer, string model, decimal price, double overallPerformance, int component)
            : base(id, manufacturer, model, price, overallPerformance, component)
        {
        }

        public override double OverallPerformance => base.OverallPerformance * 1.20;
    }
}
