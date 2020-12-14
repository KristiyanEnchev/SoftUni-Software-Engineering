using System;
using System.Transactions;

namespace ConsoleApp39
{
    class Program
    {
        static void Main(string[] args)
        {
            int hrizCount = int.Parse(Console.ReadLine());
            int rosesCount = int.Parse(Console.ReadLine());
            int lalCount = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string dayType = Console.ReadLine();
            double hrizPrice = 0;
            double rosesPrice = 0;
            double lalPrice = 0;
            if (season == "Spring" || season == "Summer")
            {
                hrizPrice = 2.00;
                rosesPrice = 4.10;
                lalPrice = 2.50;
                if (dayType == "Y")
                {
                    hrizPrice = 2.00 * 1.15;
                    rosesPrice = 4.10 * 1.15;
                    lalPrice = 2.50 * 1.15;
                }
            }
            else if (season == "Autumn" || season == "Winter")
            {
                hrizPrice = 3.75;
                rosesPrice = 4.50;
                lalPrice = 4.15;
                if (dayType == "Y")
                {
                    hrizPrice = 3.75 * 1.15;
                    rosesPrice = 4.50 * 1.15;
                    lalPrice = 4.15 * 1.15;
                }
            }
            double total = hrizCount * hrizPrice + rosesPrice * rosesCount + lalPrice * lalCount;
            if (lalCount >= 7 && season == "Spring")
            {
                total *= 0.95;
            }
            if (rosesCount >= 10 && season == "Winter")
            {
                total *= 0.90;
            }
            if (hrizCount + rosesCount + lalCount > 20)
            {
                total *= 0.80;
            }
            Console.WriteLine($"{total + 2:f2}");
        }
    }
}
