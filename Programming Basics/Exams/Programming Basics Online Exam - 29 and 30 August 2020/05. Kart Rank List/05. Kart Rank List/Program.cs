using System;

namespace ConsoleApp52
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            int gold = 0;
            int silver = 0;
            int bronze = 0;
            int bestTime = int.MaxValue;
            string bestName = "";
            while (comand != "Finish")
            {
                string name = comand;
                int minuts = int.Parse(Console.ReadLine());
                int sec = int.Parse(Console.ReadLine());
                int totalSec = minuts * 60 + sec;
                if (totalSec <= 120 && totalSec > 85)
                {
                    bronze++;
                }
                else if (totalSec <= 85 && totalSec >= 55)
                {
                    silver++;
                }
                else if (totalSec < 55)
                {
                    gold++;
                }
                if (totalSec < bestTime)
                {
                    bestTime = totalSec;
                    bestName = name;
                }
                comand = Console.ReadLine();
            }
            int bestMin = bestTime / 60;
            int bestSec = bestTime % 60;
            Console.WriteLine($"With {bestMin} minutes and {bestSec} seconds {bestName} is the winner of the day!");
            Console.WriteLine($"Today's prizes are {gold} Gold {silver} Silver and {bronze} Bronze cards!");
        }
    }
}
