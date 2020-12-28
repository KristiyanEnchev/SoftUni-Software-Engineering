using System;

namespace ConsoleApp52
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            string roundCount = Console.ReadLine();
            string fanCard = Console.ReadLine();
            string cardType = Console.ReadLine();
            double price = 0;
            if (roundCount == "five")
            {
                switch (cardType)
                {
                    case "Child":
                        price = 7.00;
                        break;
                    case "Junior":
                        price = 9.00;
                        break;
                    case "Adult":
                        price = 12.00;
                        break;
                    case "Profi":
                        price = 18.00;
                        break;
                }
            }
            else if (roundCount == "ten")
            {
                switch (cardType)
                {
                    case "Child":
                        price = 11.00;
                        break;
                    case "Junior":
                        price = 16.00;
                        break;
                    case "Adult":
                        price = 21.00;
                        break;
                    case "Profi":
                        price = 32.00;
                        break;
                }
            }
            if (fanCard == "yes")
            {
                price *= 0.80;
            }
            if (price <= money)
            {
                Console.WriteLine($"You bought {cardType} ticket for {roundCount} laps. Your change is {money - price:f2}lv.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need {price - money:f2}lv more.");
            }
        }
    }
}
