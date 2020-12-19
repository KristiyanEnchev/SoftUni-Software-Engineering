using System;

namespace ConsoleApp40
{
    class Program
    {
        static void Main(string[] args)
        {
            string cityName = Console.ReadLine();
            string packege = Console.ReadLine();
            string discount = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double price = 0;
            if (cityName == "Bansko" || cityName == "Borovets")
            {
                switch (packege)
                {
                    case "withEquipment":
                        price = 100.00;
                        if (discount == "yes")
                        {
                            price *= 0.90;
                        }
                        break;
                    case "noEquipment":
                        price = 80.00;
                        if (discount == "yes")
                        {
                            price *= 0.95;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        System.Environment.Exit(0);
                        break;
                }
            }
            else if (cityName == "Varna" || cityName == "Burgas")
            {
                switch (packege)
                {
                    case "withBreakfast":
                        price = 130.00;
                        if (discount == "yes")
                        {
                            price *= 0.88;
                        }
                        break;
                    case "noBreakfast":
                        price = 100.00;
                        if (discount == "yes")
                        {
                            price *= 0.93;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        System.Environment.Exit(0);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
                System.Environment.Exit(0);
            }
            if (days > 7)
            {
                days -= 1;
            }
            if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
            }
            else
            {
                Console.WriteLine($"The price is {price * days:f2}lv! Have a nice time!");
            }
        }
    }
}
