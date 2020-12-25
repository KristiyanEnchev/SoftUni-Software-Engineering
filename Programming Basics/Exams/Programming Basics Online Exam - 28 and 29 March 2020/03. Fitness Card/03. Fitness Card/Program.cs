using System;
using System.Text;
using System.Transactions;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            int age = int.Parse(Console.ReadLine());
            string sportType = Console.ReadLine();
            double cardPrice = 0;
            if (gender == 'm')
            {
                switch (sportType)
                {
                    case "Gym":
                        cardPrice = 42;
                        break;
                    case "Boxing":
                        cardPrice = 41;
                        break;
                    case "Yoga":
                        cardPrice = 45;
                        break;
                    case "Zumba":
                        cardPrice = 34;
                        break;
                    case "Dances":
                        cardPrice = 51;
                        break;
                    case "Pilates":
                        cardPrice = 39;
                        break;
                }
            }
            else if (gender == 'f')
            {
                switch (sportType)
                {
                    case "Gym":
                        cardPrice = 35;
                        break;
                    case "Boxing":
                        cardPrice = 37;
                        break;
                    case "Yoga":
                        cardPrice = 42;
                        break;
                    case "Zumba":
                        cardPrice = 31;
                        break;
                    case "Dances":
                        cardPrice = 53;
                        break;
                    case "Pilates":
                        cardPrice = 37;
                        break;
                }
            }
            if (age <= 19)
            {
                cardPrice *= 0.80;
            }
            if (cardPrice <= money)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sportType}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${cardPrice - money:f2} more.");
            }
        }
    }
}
