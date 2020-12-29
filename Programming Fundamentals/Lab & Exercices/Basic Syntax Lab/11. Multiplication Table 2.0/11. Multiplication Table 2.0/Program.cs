using System;

namespace ConsoleApp53
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());
            if (multiplier <= 10)
            {
                for (int i = multiplier; i <= 10; i++)
                {
                    Console.WriteLine($"{num} X {i} = {num * i}");
                }
            }
            else
            {
                Console.WriteLine($"{num} X {multiplier} = {num * multiplier}");
            }
        }
    }
}
