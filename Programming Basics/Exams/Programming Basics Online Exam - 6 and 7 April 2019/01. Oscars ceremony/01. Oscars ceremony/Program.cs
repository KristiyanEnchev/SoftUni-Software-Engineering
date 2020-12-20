using System;

namespace ConsoleApp41
{
    class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());
            double statuePrice = rent * 0.70;
            double foodPrice = statuePrice * 0.85;
            double music = foodPrice / 2;
            double totalMoneyNeeded = rent + statuePrice + foodPrice + music;
            Console.WriteLine($"{totalMoneyNeeded:f2}");
        }
    }
}
