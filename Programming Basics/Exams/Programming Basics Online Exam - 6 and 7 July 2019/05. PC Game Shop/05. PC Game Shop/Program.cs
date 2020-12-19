using System;

namespace ConsoleApp40
{
    class Program
    {
        static void Main(string[] args)
        {
            double gameCount = double.Parse(Console.ReadLine());
            int heartstone = 0;
            int fortnite = 0;
            int overwach = 0;
            int others = 0;
            for (int i = 1; i <= gameCount; i++)
            {
                string gameName = Console.ReadLine();
                if (gameName == "Hearthstone")
                {
                    heartstone++;
                }
                else if (gameName == "Fornite")
                {
                    fortnite++;
                }
                else if (gameName == "Overwatch")
                {
                    overwach++;
                }
                else
                {
                    others++;
                }
            }
            Console.WriteLine($"Hearthstone - {heartstone / gameCount * 100:f2}%");
            Console.WriteLine($"Fornite - {fortnite / gameCount * 100:f2}%");
            Console.WriteLine($"Overwatch - {overwach / gameCount * 100:f2}%");
            Console.WriteLine($"Others - {others / gameCount * 100:f2}%");
        }
    }
}
