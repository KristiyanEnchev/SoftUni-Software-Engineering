using System;

namespace ConsoleApp35
{
    class Program
    {
        static void Main(string[] args)
        {
            double skPrice = double.Parse(Console.ReadLine());
            double ccPrice = double.Parse(Console.ReadLine());
            double palCount = double.Parse(Console.ReadLine());
            double safritCount = double.Parse(Console.ReadLine());
            double oysterCount = double.Parse(Console.ReadLine());

            double palPrice = skPrice * 1.60;
            double safritPrice = ccPrice * 1.80;
            double oysterPrice = 7.50;
            double total = palCount * palPrice + safritCount * safritPrice + oysterCount * oysterPrice;

            Console.WriteLine($"{total:f2}");
        }
    }
}
