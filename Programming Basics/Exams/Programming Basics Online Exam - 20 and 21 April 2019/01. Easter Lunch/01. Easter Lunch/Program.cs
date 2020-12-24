using System;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            double easterBreadCount = double.Parse(Console.ReadLine());
            double eggCount = double.Parse(Console.ReadLine());
            double cockieCount = double.Parse(Console.ReadLine());

            double easterBreadPrice = 3.20;
            double eggPrice = 4.35;
            double cockiePrice = 5.40;
            double eggPaintPrice = (eggCount * 12) * 0.15;

            double total = easterBreadCount * easterBreadPrice + eggCount * eggPrice + cockiePrice * cockieCount + eggPaintPrice;

            Console.WriteLine($"{total:f2}");

        }
    }
}
