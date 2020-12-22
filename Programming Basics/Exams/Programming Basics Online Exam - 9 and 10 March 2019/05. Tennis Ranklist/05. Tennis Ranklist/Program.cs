using System;
using System.Net;
using System.Runtime;

namespace ConsoleApp42
{
    class Program
    {
        static void Main(string[] args)
        {
            double turnamentCount = double.Parse(Console.ReadLine());
            double startingPoints = double.Parse(Console.ReadLine());
            double points = 0;
            int wonTurnamentsCount = 0;
            for (int i = 1; i <= turnamentCount; i++)
            {
                string finishType = Console.ReadLine();
                if (finishType == "W")
                {
                    points += 2000;
                    wonTurnamentsCount++;
                }
                else if (finishType == "F")
                {
                    points += 1200;
                }
                else if (finishType == "SF")
                {
                    points += 720;
                }
            }
            double averigePoint = points / turnamentCount;
            double finishPoints = startingPoints + points;
            double procentageWon = wonTurnamentsCount / turnamentCount * 100;
            Console.WriteLine($"Final points: {finishPoints}");
            Console.WriteLine($"Average points: {Math.Floor(averigePoint)}");
            Console.WriteLine($"{procentageWon:f2}%");
        }
    }
}
