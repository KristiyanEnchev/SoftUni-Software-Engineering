using System;

namespace ConsoleApp40
{
    class Program
    {
        static void Main(string[] args)
        {
            double peopleCount = double.Parse(Console.ReadLine());
            double entrencePrice = double.Parse(Console.ReadLine());
            double deckchairPrice = double.Parse(Console.ReadLine());
            double umbrellaPrice = double.Parse(Console.ReadLine());
            double entranceMoney = peopleCount * entrencePrice;
            double deckchairCount = Math.Ceiling(peopleCount * 0.75);
            double deckchairMoney = deckchairCount * deckchairPrice;
            double umbrelaCount = Math.Ceiling(peopleCount / 2);
            double umbrelaMoney = umbrelaCount * umbrellaPrice;
            double total = umbrelaMoney + deckchairMoney + entranceMoney;
            Console.WriteLine($"{total:f2} lv.");

        }
    }
}
