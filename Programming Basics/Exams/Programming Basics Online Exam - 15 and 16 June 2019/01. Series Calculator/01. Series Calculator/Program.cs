using System;
using System.Globalization;

namespace ConsoleApp33
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int seasonCount = int.Parse(Console.ReadLine());
            int episodeCount = int.Parse(Console.ReadLine());
            double time = double.Parse(Console.ReadLine());

            double timeforAseason = episodeCount * (time * 1.20) + 10;
            double totalTime = timeforAseason * seasonCount;
            Console.WriteLine($"Total time needed to watch the {name} series is {totalTime} minutes.");

        }
    }
}
