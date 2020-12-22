using System;
using System.Runtime;

namespace ConsoleApp42
{
    class Program
    {
        static void Main(string[] args)
        {
            double win = 0;
            double lose = 0;
            int gameCount = 0;
            while (true)
            {
                string turnamentName = Console.ReadLine();
                if (turnamentName == "End of tournaments")
                {
                    break;
                }
                int games = int.Parse(Console.ReadLine());
                int gamesPerTournamentCount = 0;
                for (int i = 1; i <= games; i++)
                {
                    int desiPoints = int.Parse(Console.ReadLine());
                    int aotherPoints = int.Parse(Console.ReadLine());
                    if (desiPoints > aotherPoints)
                    {
                        win++;
                        gamesPerTournamentCount++;
                        Console.WriteLine($"Game {gamesPerTournamentCount} of tournament {turnamentName}: win with {desiPoints - aotherPoints} points.");
                    }
                    else
                    {
                        lose++;
                        gamesPerTournamentCount++;
                        Console.WriteLine($"Game {gamesPerTournamentCount} of tournament {turnamentName}: lost with {aotherPoints - desiPoints} points.");
                    }
                    gameCount++;
                }
            }
            Console.WriteLine($"{win / gameCount * 100:f2}% matches win");
            Console.WriteLine($"{lose / gameCount * 100:f2}% matches lost");
        }
    }
}
