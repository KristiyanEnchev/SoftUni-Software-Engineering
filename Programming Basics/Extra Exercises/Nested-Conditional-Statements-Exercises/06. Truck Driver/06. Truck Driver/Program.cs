using System;
using System.Transactions;

namespace ConsoleApp39
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kilometers = double.Parse(Console.ReadLine());
            double price = 0;
            if (kilometers <= 5000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        price = 0.75;
                        break;
                    case "Summer":
                        price = 0.90;
                        break;
                    case "Winter":
                        price = 1.05;
                        break;
                }
            }
            else if (kilometers > 5000 && kilometers <= 10000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        price = 0.95;
                        break;
                    case "Summer":
                        price = 1.10;
                        break;
                    case "Winter":
                        price = 1.25;
                        break;
                }
            }
            else if (kilometers > 10000 && kilometers <= 20000)
            {
                price = 1.45;
            }
            double total = ((price * kilometers) * 4) * 0.90;
            Console.WriteLine($"{total:f2}");
        }
    }
}
