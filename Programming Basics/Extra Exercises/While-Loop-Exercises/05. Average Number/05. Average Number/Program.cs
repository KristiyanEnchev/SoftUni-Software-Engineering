using System;

namespace ConsoleApp44
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            double total = 0;
            for (int i = 1; i <= num; i++)
            {
                double num1 = double.Parse(Console.ReadLine());
                total += num1;
            }
            Console.WriteLine($"{total / num:f2}");
        }
    }
}
