using System;

namespace ConsoleApp40
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int graphicCardsCount = int.Parse(Console.ReadLine());
            int procesorCount = int.Parse(Console.ReadLine());
            int ramCount = int.Parse(Console.ReadLine());
            double totalgraphicPrice = graphicCardsCount * 250.00;
            double procesorPrice = totalgraphicPrice * 0.35;
            double totalProcesorPrice = procesorCount * procesorPrice;
            double ramPrice = totalgraphicPrice * 0.10;
            double totalRamPrice = ramPrice * ramCount;
            double totalPrice = totalgraphicPrice + totalProcesorPrice + totalRamPrice;
            if (graphicCardsCount > procesorCount)
            {
                totalPrice *= 0.85;
            }
            if (budget >= totalPrice)
            {
                Console.WriteLine($"You have {budget - totalPrice:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalPrice - budget:f2} leva more!");
            }
        }
    }
}
