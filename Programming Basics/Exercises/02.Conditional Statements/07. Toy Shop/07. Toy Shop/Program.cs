using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            double excursion = double.Parse(Console.ReadLine());
            double puzzCount = double.Parse(Console.ReadLine());
            double dollCount = double.Parse(Console.ReadLine());
            double bearCount = double.Parse(Console.ReadLine());
            double minionCount = double.Parse(Console.ReadLine());
            double truckCount = double.Parse(Console.ReadLine());

            double totalPrice = (puzzCount * 2.60) + (dollCount * 3) + (bearCount * 4.10) + (minionCount * 8.20) + (truckCount * 2.00);
            double toysCount = puzzCount + dollCount + bearCount + minionCount + truckCount;

            if (toysCount >= 50)
            {
                totalPrice *= 0.75;
            }
            totalPrice *= 0.90;
            if (totalPrice >= excursion)
            {
                double extra = totalPrice - excursion;
                Console.WriteLine($"Yes! {extra:f2} lv left.");
            }
            else
            {
                double needed = excursion - totalPrice;
                Console.WriteLine($"Not enough money! {needed:f2} lv needed.");
            }
        }
    }
}
