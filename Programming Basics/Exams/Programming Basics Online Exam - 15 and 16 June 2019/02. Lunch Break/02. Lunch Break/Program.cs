using System;
using System.Globalization;

namespace ConsoleApp33
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int timeForsieris = int.Parse(Console.ReadLine());
            int breakk = int.Parse(Console.ReadLine());

            double lunchTime = breakk / 8.00;
            double chillTime = breakk / 4.00;

            double total = chillTime + lunchTime + timeForsieris;

            if (breakk >= total)
            {
                Console.WriteLine($"You have enough time to watch {name} and left with {Math.Ceiling(breakk - total)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {name}, you need {Math.Ceiling(total - breakk)} more minutes.");
            }
        }
    }
}
