using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            decimal budget = decimal.Parse(Console.ReadLine());

            List<decimal> allNewPrices = new List<decimal>(list.Count);
            decimal startBudget = budget;

            for (int i = 0; i < list.Count; i++)
            {
                string[] items = list[i].Split("->", StringSplitOptions.RemoveEmptyEntries);
                if (items[0] == "Clothes")
                {
                    decimal price = decimal.Parse(items[1]);
                    if (price <= 50.00m && price <= budget)
                    {
                        budget -= price;
                        allNewPrices.Add(price);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (items[0] == "Shoes")
                {
                    decimal price = decimal.Parse(items[1]);
                    if (price <= 35.00m && price <= budget)
                    {
                        budget -= price;
                        allNewPrices.Add(price);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (items[0] == "Accessories")
                {
                    decimal price = decimal.Parse(items[1]);
                    if (price <= 20.50m && price <= budget)
                    {
                        budget -= price;
                        allNewPrices.Add(price);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            for (int i = 0; i < allNewPrices.Count; i++)
            {
                allNewPrices[i] = decimal.Round(allNewPrices[i] * 1.40m, 2);
            }

            Console.WriteLine(string.Join(" ", allNewPrices));
            Console.WriteLine($"Profit: {(allNewPrices.Sum() - startBudget) + budget:f2}");

            if (allNewPrices.Sum() + budget >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
