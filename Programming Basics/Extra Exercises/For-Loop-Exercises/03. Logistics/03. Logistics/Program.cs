using System;

namespace ConsoleApp44
{
    class Program
    {
        static void Main(string[] args)
        {
            int cargo = int.Parse(Console.ReadLine());
            double bus = 0;
            double truck = 0;
            double train = 0;
            double totalTons = 0;
            for (int i = 1; i <= cargo; i++)
            {
                int tonsOfCargo = int.Parse(Console.ReadLine());
                if (tonsOfCargo <= 3)
                {
                    bus += tonsOfCargo;
                    totalTons += tonsOfCargo;
                }
                else if (tonsOfCargo >= 4 && tonsOfCargo <= 11)
                {
                    truck += tonsOfCargo;
                    totalTons += tonsOfCargo;
                }
                else if (tonsOfCargo >= 12)
                {
                    train += tonsOfCargo;
                    totalTons += tonsOfCargo;
                }
            }
            double averagePrice = (bus * 200 + truck * 175 + train * 120) / totalTons;
            Console.WriteLine($"{averagePrice:f2}");
            Console.WriteLine($"{bus / totalTons * 100:f2}%");
            Console.WriteLine($"{truck / totalTons * 100:f2}%");
            Console.WriteLine($"{train / totalTons * 100:f2}%");
        }
    }
}
