using System;
using System.Transactions;

namespace ConsoleApp39
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int peopleCount = int.Parse(Console.ReadLine());
            double price = 0;
            if (peopleCount >= 1 && peopleCount <= 4)
            {
                budget *= 0.25;
            }
            else if (peopleCount >= 5 && peopleCount <= 9)
            {
                budget *= 0.40;
            }
            else if (peopleCount >= 10 && peopleCount <= 24)
            {
                budget *= 0.50;
            }
            else if (peopleCount >= 25 && peopleCount <= 49)
            {
                budget *= 0.60;
            }
            else if (peopleCount >= 50)
            {
                budget *= 0.75;
            }
            if (category == "VIP")
            {
                price = 499.99;
            }
            else if (category == "Normal")
            {
                price = 249.99;
            }
            double totalMoney = price * peopleCount;
            if (budget >= totalMoney)
            {
                Console.WriteLine($"Yes! You have {budget - totalMoney:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalMoney - budget:f2} leva.");
            }
        }
    }
}
