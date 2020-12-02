using System;

namespace ConsoleApp35
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double windols = (1.5 * 1.5) * 2;
            double sideArea = ((x * y) * 2) - windols;
            double door = 1.2 * 2;
            double frontArea = (x * x) - door;
            double frontAndBack = frontArea + (x * x);
            double totalGreen = sideArea + frontAndBack;
            Console.WriteLine($"{totalGreen / 3.4:f2}");
            double roofSides = 2 * (x * y);
            double roofFrontAndBack = 2 * (x * h / 2);
            double totalRoof = roofSides + roofFrontAndBack;
            double totalRed = totalRoof / 4.3;
            Console.WriteLine($"{totalRed:f2}");
        }
    }
}
