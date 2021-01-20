using System;
using System.Linq;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Print(number);
        }

        static void Print(int num)
        {
            if (num < 0)
            {
                Console.WriteLine($"The number {num} is negative.");
            }
            else if (num > 0)
            {
                Console.WriteLine($"The number {num} is positive.");
            }
            else
            {
                Console.WriteLine($"The number {num} is zero.");
            }
        }
    }
}
