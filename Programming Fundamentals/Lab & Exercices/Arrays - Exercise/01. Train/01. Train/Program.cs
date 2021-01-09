using System;
using System.Linq;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagonCount = int.Parse(Console.ReadLine());
            int[] pasengerSequanceInWagons = new int[wagonCount];

            for (int i = 0; i < wagonCount; i++)
            {
                int pasangerCount = int.Parse(Console.ReadLine());
                pasengerSequanceInWagons[i] = pasangerCount;
            }
            Console.WriteLine(string.Join(" ", pasengerSequanceInWagons));
            Console.WriteLine(pasengerSequanceInWagons.Sum());
        }
    }
}

