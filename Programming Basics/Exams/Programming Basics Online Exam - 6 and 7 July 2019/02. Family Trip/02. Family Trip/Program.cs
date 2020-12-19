using System;

namespace ConsoleApp40
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nightsCount = int.Parse(Console.ReadLine());
            double nightPrice = double.Parse(Console.ReadLine());
            double procentCount = double.Parse(Console.ReadLine());
            double procent = procentCount * 0.01;
            if (nightsCount > 7)
            {
                nightPrice *= 0.95;
            }
            double aditionalCosts = budget * procent;
            double price = nightsCount * nightPrice;
            double totalCost = price + aditionalCosts;
            if (budget >= totalCost)
            {
                Console.WriteLine($"Ivanovi will be left with {budget - totalCost:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{totalCost - budget:f2} leva needed.");
            }
        }
    }
}
