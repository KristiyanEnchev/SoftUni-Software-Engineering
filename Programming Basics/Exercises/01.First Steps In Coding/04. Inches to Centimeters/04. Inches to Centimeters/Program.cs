using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            double inches = double.Parse(Console.ReadLine());
            double calculate = inches * 2.54;
            Console.WriteLine(calculate);

        }
    }
}
