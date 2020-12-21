using System;

namespace ConsoleApp33
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string package = Console.ReadLine();
            int ticketCount = int.Parse(Console.ReadLine());
            double price = 0;
            if (movie == "John Wick")
            {
                switch (package)
                {
                    case "Drink":
                        price = 12.00;
                        break;
                    case "Popcorn":
                        price = 15.00;
                        break;
                    case "Menu":
                        price = 19.00;
                        break;
                }
            }
            else if (movie == "Star Wars")
            {
                switch (package)
                {
                    case "Drink":
                        price = 18.00;
                        break;
                    case "Popcorn":
                        price = 25.00;
                        break;
                    case "Menu":
                        price = 30.00;
                        break;
                }
                if (ticketCount >= 4)
                {
                    price *= 0.70;
                }
            }
            else if (movie == "Jumanji")
            {
                switch (package)
                {
                    case "Drink":
                        price = 9.00;
                        break;
                    case "Popcorn":
                        price = 11.00;
                        break;
                    case "Menu":
                        price = 14.00;
                        break;
                }
                if (ticketCount == 2)
                {
                    price *= 0.85;
                }
            }
            double total = price * ticketCount;
            Console.WriteLine($"Your bill is {total:f2} leva.");
        }
    }
}
