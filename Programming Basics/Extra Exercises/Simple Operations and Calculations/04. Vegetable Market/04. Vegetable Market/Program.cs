using System;

namespace ConsoleApp35
{
    class Program
    {
        static void Main(string[] args)
        {
            double vegiPrice = double.Parse(Console.ReadLine());
            double fruitPRice = double.Parse(Console.ReadLine());
            double vegiCount = double.Parse(Console.ReadLine());
            double fruitCount = double.Parse(Console.ReadLine());
            double total = vegiPrice * vegiCount + fruitPRice * fruitCount;
            double inEuro = total / 1.94;
            Console.WriteLine($"{inEuro:f2}");
        }
    }
}
