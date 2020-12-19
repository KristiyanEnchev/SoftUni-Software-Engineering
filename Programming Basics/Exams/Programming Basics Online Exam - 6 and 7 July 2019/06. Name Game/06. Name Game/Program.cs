using System;

namespace ConsoleApp40
{
    class Program
    {
        static void Main(string[] args)
        {
            string winerName = "";
            int points = 0;
            double topPoints = double.MinValue;
            string name = Console.ReadLine();
            while (name != "Stop")
            {
                for (int i = 0; i < name.Length; i++)
                {
                    char letter = (char)name[i];
                    int ASCII = letter;
                    double num = double.Parse(Console.ReadLine());
                    if (num == ASCII)
                    {
                        points += 10;
                    }
                    else
                    {
                        points += 2;
                    }
                }
                if (points >= topPoints)
                {
                    topPoints = points;
                    winerName = name;
                }
                points = 0;
                name = Console.ReadLine();
            }
            Console.WriteLine($"The winner is {winerName} with {topPoints} points!");
        }
    }
}
