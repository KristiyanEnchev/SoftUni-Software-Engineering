using System;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            double peopleCount = double.Parse(Console.ReadLine());
            double entrencePrice = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            double cakePrice = budget * 0.10;

            if (peopleCount >= 10 && peopleCount <= 15)
            {
                entrencePrice *= 0.85;
            }
            else if (peopleCount > 15 && peopleCount <= 20)
            {
                entrencePrice *= 0.80;
            }
            else if (peopleCount > 20)
            {
                entrencePrice *= 0.75;
            }

            double total = (peopleCount * entrencePrice) + cakePrice;

            if (total <= budget)
            {
                Console.WriteLine($"It is party time! {budget - total:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"No party! {total - budget:f2} leva needed.");
            }
        }
    }
}
