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
            double price = 0;
            string clas = "";
            string car = "";
            if (season == "Summer")
            {
                if (budget <= 100)
                {
                    clas = "Economy class";
                    car = "Cabrio";
                    price = budget * 0.35;
                }
                else if (budget > 100 && budget <= 500)
                {
                    clas = "Compact class";
                    car = "Cabrio";
                    price = budget * 0.45;
                }
                else if (budget > 500)
                {
                    clas = "Luxury class";
                    car = "Jeep";
                    price = budget * 0.90;
                }
            }
            else if (season == "Winter")
            {
                if (budget <= 100)
                {
                    clas = "Economy class";
                    car = "Jeep";
                    price = budget * 0.65;
                }
                else if (budget > 100 && budget <= 500)
                {
                    clas = "Compact class";
                    car = "Jeep";
                    price = budget * 0.80;
                }
                else if (budget > 500)
                {
                    clas = "Luxury class";
                    car = "Jeep";
                    price = budget * 0.90;
                }
            }
            Console.WriteLine($"{clas}");
            Console.WriteLine($"{car} - {price:f2}");
        }
    }
}
