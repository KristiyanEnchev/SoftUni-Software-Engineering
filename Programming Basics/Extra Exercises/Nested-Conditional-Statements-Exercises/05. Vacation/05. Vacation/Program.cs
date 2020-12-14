using System;
using System.Transactions;

namespace ConsoleApp39
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string location = "";
            string place = "";
            double price = 0;
            if (season == "Summer")
            {
                if (budget <= 1000)
                {
                    place = "Camp";
                    location = "Alaska";
                    price = budget * 0.65;
                }
                else if (budget > 100 && budget <= 3000)
                {
                    place = "Hut";
                    location = "Alaska";
                    price = budget * 0.80;
                }
                else if (budget > 3000)
                {
                    place = "Hotel";
                    location = "Alaska";
                    price = budget * 0.90;
                }
            }
            else if (season == "Winter")
            {
                if (budget <= 1000)
                {
                    place = "Camp";
                    location = "Morocco";
                    price = budget * 0.45;
                }
                else if (budget > 100 && budget <= 3000)
                {
                    place = "Hut";
                    location = "Morocco";
                    price = budget * 0.60;
                }
                else if (budget > 3000)
                {
                    place = "Hotel";
                    location = "Morocco";
                    price = budget * 0.90;
                }
            }
            Console.WriteLine($"{location} - {place} - {price:f2}");
        }
    }
}
