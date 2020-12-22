using System;
using System.Net;
using System.Runtime;

namespace ConsoleApp42
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();
            double point = 301;
            bool giveUp = false;
            double unseccesful = 0;
            double succesful = 0;
            while (true)
            {
                if (point == 0)
                {
                    break;
                }
                string sectorType = Console.ReadLine();
                if (sectorType == "Retire")
                {
                    giveUp = true;
                    break;
                }
                double pointInSector = double.Parse(Console.ReadLine());
                if (sectorType == "Double")
                {
                    pointInSector *= 2;
                }
                else if (sectorType == "Triple")
                {
                    pointInSector *= 3;
                }
                point -= pointInSector;
                if (point < 0)
                {
                    unseccesful++;
                    point += pointInSector;
                    continue;
                }
                else
                {
                    succesful++;
                }
            }
            if (giveUp)
            {
                Console.WriteLine($"{playerName} retired after {unseccesful} unsuccessful shots.");
            }
            else
            {
                Console.WriteLine($"{playerName} won the leg with {succesful} shots.");
            }
        }
    }
}
