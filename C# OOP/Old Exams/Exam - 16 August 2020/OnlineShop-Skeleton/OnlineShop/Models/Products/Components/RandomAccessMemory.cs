using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class RandomAccessMemory : Component
    {
        //private const double randomAccessMemoryModifier = 1.20;

        public RandomAccessMemory(int id, string manufacturer, string model, decimal price, double overallPerformance, int component)
            : base(id, manufacturer, model, price, overallPerformance, component)
        {
        }

        public override double OverallPerformance => base.OverallPerformance * 1.20;
    }
}
