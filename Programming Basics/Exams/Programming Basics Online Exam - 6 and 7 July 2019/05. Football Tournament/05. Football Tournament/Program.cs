using System;

namespace ConsoleApp40
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            int gameCount = int.Parse(Console.ReadLine());
            int pointsCount = 0;
            double w = 0;
            double d = 0;
            double l = 0;
            double procent = 0;
            for (int i = 1; i <= gameCount; i++)
            {
                char condition = char.Parse(Console.ReadLine());
                if (condition == 'W')
                {
                    w++;
                    pointsCount += 3;
                }
                else if (condition == 'D')
                {
                    d++;
                    pointsCount += 1;
                }
                else if (condition == 'L')
                {
                    l++;
                    pointsCount += 0;
                }
                procent = w / i * 100;
            }
            if (gameCount < 1)
            {
                Console.WriteLine($"{teamName} hasn't played any games during this season.");
            }
            else
            {
                Console.WriteLine($"{teamName} has won {pointsCount} points during this season.");
                Console.WriteLine("Total stats:");
                Console.WriteLine($"## W: {w}");
                Console.WriteLine($"## D: {d}");
                Console.WriteLine($"## L: {l}");
                Console.WriteLine($"Win rate: {procent:f2}%");
            }
        }
    }
}
