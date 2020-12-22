using System;

namespace ConsoleApp43
{
    class Program
    {
        static void Main(string[] args)
        {
            double tax = double.Parse(Console.ReadLine());
            double snekers = tax * 0.60;
            double outfit = snekers * 0.80;
            double ball = outfit / 4;
            double accesory = ball / 5;
            double total = tax + snekers + outfit + ball + accesory;
            Console.WriteLine($"{total:f2}");
        }
    }
}
