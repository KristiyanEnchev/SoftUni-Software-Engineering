using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class VideoCard : Component
    {
        //private const double videoCardModifier = 1.15;

        public VideoCard(int id, string manufacturer, string model, decimal price, double overallPerformance, int component )
            : base(id, manufacturer, model, price, overallPerformance, component)
        {
        }

        public override double OverallPerformance => base.OverallPerformance * 1.15;
    }
}
