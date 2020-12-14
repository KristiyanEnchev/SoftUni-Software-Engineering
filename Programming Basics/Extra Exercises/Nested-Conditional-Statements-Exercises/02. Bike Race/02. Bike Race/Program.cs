using System;
using System.Transactions;

namespace ConsoleApp39
{
    class Program
    {
        static void Main(string[] args)
        {
            double juniorCount = double.Parse(Console.ReadLine());
            double seniorCount = double.Parse(Console.ReadLine());
            string trackType = Console.ReadLine();
            double junior = 0;
            double senior = 0;
            switch (trackType)
            {
                case "trail":
                    junior = 5.5;
                    senior = 7.0;
                    break;
                case "cross-country":
                    junior = 8.00;
                    senior = 9.50;
                    if (juniorCount + seniorCount >= 50)
                    {
                        junior *= 0.75;
                        senior *= 0.75;
                    }
                    break;
                case "downhill":
                    junior = 12.25;
                    senior = 13.75;
                    break;
                case "road":
                    junior = 20.00;
                    senior = 21.50;
                    break;
            }
            double total = junior * juniorCount + senior * seniorCount;
            double afterCost = total * 0.95;
            Console.WriteLine($"{afterCost:f2}");
        }
    }
}
