using System;
using System.Xml.Linq;

namespace ConsoleApp37
{
    class Program
    {
        static void Main(string[] args)
        {
            double magnoCount = double.Parse(Console.ReadLine());
            double zimbCount = double.Parse(Console.ReadLine());
            double rosesCount = double.Parse(Console.ReadLine());
            double kaktusCount = double.Parse(Console.ReadLine());
            double presentPrice = double.Parse(Console.ReadLine());
            double total = magnoCount * 3.25 + zimbCount * 4.00 + rosesCount * 3.50 + kaktusCount * 8.00;
            double moneyLeft = total * 0.95;
            if (presentPrice <= moneyLeft)
            {
                Console.WriteLine($"She is left with {Math.Floor(moneyLeft - presentPrice)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(presentPrice - moneyLeft)} leva.");
            }
        }
    }
}
