using System;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            double peopleCount = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double easterBreadCount = Math.Ceiling(peopleCount / 3);
            double eggCount = peopleCount * 2;

            double totalEasterBreadPrice = easterBreadCount * 4.00;
            double totalEggPrice = eggCount * 0.45;
            double totalPrice = totalEasterBreadPrice + totalEggPrice;

            if (totalPrice <= budget)
            {
                Console.WriteLine($"Lyubo bought {easterBreadCount} Easter bread and {eggCount} eggs.");
                Console.WriteLine($"He has {budget - totalPrice:f2} lv. left.");
            }
            else
            {
                Console.WriteLine("Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {totalPrice - budget:f2} lv. more.");
            }
        }
    }
}
