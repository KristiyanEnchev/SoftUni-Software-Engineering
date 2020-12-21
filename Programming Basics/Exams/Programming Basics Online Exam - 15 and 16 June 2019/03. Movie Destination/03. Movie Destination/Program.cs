using System;
using System.ComponentModel;
using System.Security.Cryptography;

namespace ConsoleApp34
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destionation = Console.ReadLine();
            string season = Console.ReadLine();
            int dayCount = int.Parse(Console.ReadLine());
            double price = 0;
            if (season == "Summer")
            {
                switch (destionation)
                {
                    case "Dubai":
                        price = 40000 * 0.70;
                        break;
                    case "Sofia":
                        price = 12500 * 1.25;
                        break;
                    case "London":
                        price = 20250;
                        break;
                }
            }
            else if (season == "Winter")
            {
                switch (destionation)
                {
                    case "Dubai":
                        price = 45000 * 0.70;
                        break;
                    case "Sofia":
                        price = 17000 * 1.25;
                        break;
                    case "London":
                        price = 24000;
                        break;
                }
            }
            double total = price * dayCount;
            if (budget >= total)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {budget - total:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {total - budget:f2} leva more!");
            }
        }
    }
}
