using System;

namespace ConsoleApp35
{
    class Program
    {
        static void Main(string[] args)
        {
            double c = double.Parse(Console.ReadLine());
            double convert = c * 1.80 + 32.00;
            Console.WriteLine($"{convert:f2}");
        }
    }
}
