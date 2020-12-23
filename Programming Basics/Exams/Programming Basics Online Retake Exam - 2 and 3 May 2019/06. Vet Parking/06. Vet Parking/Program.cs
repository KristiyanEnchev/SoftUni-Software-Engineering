using System;

namespace ConsoleApp36
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayCount = int.Parse(Console.ReadLine());
            int hourCount = int.Parse(Console.ReadLine());
            double price = 0;
            double total = 0;
            for (int i = 1; i <= dayCount; i++)
            {
                price = 0;
                for (int j = 1; j <= hourCount; j++)
                {
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        price += 2.50;
                    }
                    else if (i % 2 != 0 && j % 2 == 0)
                    {
                        price += 1.25;
                    }
                    else
                    {
                        price += 1.00;
                    }
                }
                Console.WriteLine($"Day: {i} - {price:f2} leva");
                total += price;
            }
            Console.WriteLine($"Total: {total:f2} leva");
        }
    }
}
