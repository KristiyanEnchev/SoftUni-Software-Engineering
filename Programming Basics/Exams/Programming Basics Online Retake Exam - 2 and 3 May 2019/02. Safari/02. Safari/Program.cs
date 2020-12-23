using System;

namespace ConsoleApp36
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double litersGass = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            double gasPrice = 0;
            double total = 0;
            if (day == "Saturday")
            {
                gasPrice = litersGass * 2.10;
                total = (gasPrice + 100) * 0.90;
            }
            else if (day == "Sunday")
            {
                gasPrice = litersGass * 2.10;
                total = (gasPrice + 100) * 0.80;
            }
            if (budget >= total)
            {
                Console.WriteLine($"Safari time! Money left: {budget - total:f2} lv. ");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {total - budget:f2} lv.");
            }
        }
    }
}
