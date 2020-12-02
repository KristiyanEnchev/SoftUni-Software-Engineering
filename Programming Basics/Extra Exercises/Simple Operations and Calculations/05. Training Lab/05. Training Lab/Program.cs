using System;

namespace ConsoleApp35
{
    class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            if (3 <= h || h <= w || w <= 100)
            {
                double wSm = w * 100;
                double hSm = h * 100;
                double rows = Math.Floor((hSm - 100) / 70);
                double colums = Math.Floor(wSm / 120);
                double total = (rows * colums) - 3;
                Console.WriteLine($"{Math.Floor(total)}");
            }
            else
            {
                w = double.Parse(Console.ReadLine());
                h = double.Parse(Console.ReadLine());
            }
        }
    }
}
