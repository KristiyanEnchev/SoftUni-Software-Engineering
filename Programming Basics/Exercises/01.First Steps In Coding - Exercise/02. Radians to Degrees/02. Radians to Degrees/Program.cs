using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            double angle = double.Parse(Console.ReadLine());

            double degree = angle * 180 / Math.PI;

            Console.WriteLine(Math.Round(degree));
        }
    }
}
