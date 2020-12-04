using System;

namespace ConsoleApp37
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            double p1 = double.Parse(Console.ReadLine());
            double p2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double totalP1 = p1 * h;
            double totalP2 = p2 * h;
            double totalFill = totalP1 + totalP2;
            double totalFillProcent = totalFill / capacity * 100;
            double p1Procent = totalP1 / totalFill * 100;
            double p2Procent = totalP2 / totalFill * 100;
            if (capacity >= totalFill)
            {
                Console.WriteLine($"The pool is {totalFillProcent:f2}% full. Pipe 1: {p1Procent:f2}%. Pipe 2: {p2Procent:f2}%.");
            }
            else
            {
                Console.WriteLine($"For {h:f2} hours the pool overflows with {totalFill - capacity:f2} liters.");
            }
        }
    }
}
