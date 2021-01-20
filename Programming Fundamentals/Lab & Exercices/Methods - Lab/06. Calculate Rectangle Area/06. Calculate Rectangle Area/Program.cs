using System;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double hight = double.Parse(Console.ReadLine());

            double area = CalculateArea(width, hight);
            Console.WriteLine(area);
        }

        static double CalculateArea(double width, double highrt)
        {
            return width * highrt;
        }
    }
}
