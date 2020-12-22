using System;

namespace ConsoleApp42
{
    class Program
    {
        static void Main(string[] args)
        {
            string stageOfTurnament = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int ticketCount = int.Parse(Console.ReadLine());
            string picturWithTrophy = Console.ReadLine();
            double price = 0;
            if (stageOfTurnament == "Quarter final")
            {
                switch (ticketType)
                {
                    case "Standard":
                        price = 55.50;
                        break;
                    case "Premium":
                        price = 105.20;
                        break;
                    case "VIP":
                        price = 118.90;
                        break;
                }
            }
            else if (stageOfTurnament == "Semi final")
            {
                switch (ticketType)
                {
                    case "Standard":
                        price = 75.88;
                        break;
                    case "Premium":
                        price = 125.22;
                        break;
                    case "VIP":
                        price = 300.40; ;
                        break;
                }
            }
            else if (stageOfTurnament == "Final")
            {
                switch (ticketType)
                {
                    case "Standard":
                        price = 110.10;
                        break;
                    case "Premium":
                        price = 160.66;
                        break;
                    case "VIP":
                        price = 400.00;
                        break;
                }
            }
            double totalPrice = price * ticketCount;
            if (totalPrice > 4000)
            {
                totalPrice *= 0.75;
            }
            else if (totalPrice > 2500)
            {
                totalPrice *= 0.90;
                if (picturWithTrophy == "Y")
                {
                    totalPrice += ticketCount * 40.00;
                }
            }
            else
            {
                if (picturWithTrophy == "Y")
                {
                    totalPrice += ticketCount * 40.00;
                }
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
