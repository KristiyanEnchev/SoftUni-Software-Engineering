using System;

namespace ConsoleApp40
{
    class Program
    {
        static void Main(string[] args)
        {
            string beverage = Console.ReadLine();
            string sugarType = Console.ReadLine();
            int beverageCount = int.Parse(Console.ReadLine());
            double price = 0;
            if (beverage == "Espresso")
            {
                switch (sugarType)
                {
                    case "Without":
                        price = 0.90;
                        break;
                    case "Normal":
                        price = 1.00;
                        break;
                    case "Extra":
                        price = 1.20;
                        break;
                }
            }
            else if (beverage == "Cappuccino")
            {
                switch (sugarType)
                {
                    case "Without":
                        price = 1.00;
                        break;
                    case "Normal":
                        price = 1.20;
                        break;
                    case "Extra":
                        price = 1.60;
                        break;
                }
            }
            else if (beverage == "Tea")
            {
                switch (sugarType)
                {
                    case "Without":
                        price = 0.50;
                        break;
                    case "Normal":
                        price = 0.60;
                        break;
                    case "Extra":
                        price = 0.70;
                        break;
                }
            }
            if (sugarType == "Without")
            {
                price *= 0.65;
            }
            if (beverage == "Espresso" && beverageCount >= 5)
            {
                price *= 0.75;
            }
            double total = price * beverageCount;
            if (total > 15)
            {
                total *= 0.80;
            }
            Console.WriteLine($"You bought {beverageCount} cups of {beverage} for {total:f2} lv.");
        }
    }
}
