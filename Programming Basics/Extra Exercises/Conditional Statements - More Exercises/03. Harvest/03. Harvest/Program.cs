using System;

namespace ConsoleApp37
{
    class Program
    {
        static void Main(string[] args)
        {
            double loze = double.Parse(Console.ReadLine());
            double grozde = double.Parse(Console.ReadLine());
            double wineNeeded = double.Parse(Console.ReadLine());
            double peopleCount = double.Parse(Console.ReadLine());
            double allGrozde = grozde * loze;
            double grozdeForWine = allGrozde * 0.40;
            double wineProduced = grozdeForWine / 2.5;
            if (wineProduced < wineNeeded)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(wineNeeded - wineProduced)} liters wine needed.");
            }
            else
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wineProduced)} liters.");
                Console.WriteLine($"{Math.Ceiling(wineProduced - wineNeeded)} liters left -> {Math.Ceiling(Math.Ceiling(wineProduced - wineNeeded) / peopleCount)} liters per person.");
            }
        }
    }
}
