using System;
using System.Transactions;

namespace ConsoleApp41
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());
            double clothsPrice = double.Parse(Console.ReadLine());
            double decorPrice = budget * 0.10;
            if (peopleCount > 150)
            {
                clothsPrice *= 0.90;
            }
            double totalPrice = decorPrice + clothsPrice * peopleCount;
            if (budget < totalPrice)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {totalPrice - budget:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - totalPrice:f2} leva left.");
            }
        }
    }
}
