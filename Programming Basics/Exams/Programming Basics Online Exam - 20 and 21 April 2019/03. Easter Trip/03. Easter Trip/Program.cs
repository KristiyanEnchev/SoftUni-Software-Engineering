using System;
using System.Security.Cryptography;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());
            double priceForNight = 0;
            if (destination == "France")
            {
                switch (dates)
                {
                    case "21-23":
                        priceForNight = 30;
                        break;
                    case "24-27":
                        priceForNight = 35;
                        break;
                    case "28-31":
                        priceForNight = 40;
                        break;
                }
            }
            else if (destination == "Italy")
            {
                switch (dates)
                {
                    case "21-23":
                        priceForNight = 28;
                        break;
                    case "24-27":
                        priceForNight = 32;
                        break;
                    case "28-31":
                        priceForNight = 39;
                        break;
                }
            }
            else if (destination == "Germany")
            {
                switch (dates)
                {
                    case "21-23":
                        priceForNight = 32;
                        break;
                    case "24-27":
                        priceForNight = 37;
                        break;
                    case "28-31":
                        priceForNight = 43;
                        break;
                }
            }
            Console.WriteLine($"Easter trip to {destination} : {nightsCount * priceForNight:f2} leva.");
        }
    }
}
