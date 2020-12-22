using System;

namespace ConsoleApp43
{
    class Program
    {
        static void Main(string[] args)
        {
            double tenisRocketPrice = double.Parse(Console.ReadLine());
            int tenisRocketCount = int.Parse(Console.ReadLine());
            int sneakersCount = int.Parse(Console.ReadLine());
            double tenisRockets = tenisRocketPrice * tenisRocketCount;
            double sneakersPrice = tenisRocketPrice / 6;
            double totalSneakersPrice = sneakersCount * sneakersPrice;
            double diffrentEquipment = (tenisRockets + totalSneakersPrice) * 0.20;
            double total = tenisRockets + totalSneakersPrice + diffrentEquipment;
            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(total / 8)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(total - (total / 8))}");
        }
    }
}
