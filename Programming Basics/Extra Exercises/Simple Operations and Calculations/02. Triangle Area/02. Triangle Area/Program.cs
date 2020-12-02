using System;

namespace ConsoleApp35
{
    class Program
    {
        static void Main(string[] args)
        {
            double b1 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double area = b1 * h / 2;
            Console.WriteLine($"{area:f2}");
        }
    }
}
