using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideA = double.Parse(Console.ReadLine());
            double area = sideA * sideA;
            Console.WriteLine(area);
        }
    }
}
