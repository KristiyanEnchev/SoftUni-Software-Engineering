using System;

namespace ConsoleApp37
{
    class Program
    {
        static void Main(string[] args)
        {
            int weekends = int.Parse(Console.ReadLine());
            int workingDays = 365 - weekends;
            int HPlayInWorkingDays = workingDays * 63;
            int HPlayInWeekends = weekends * 127;
            int totalPlayTime = HPlayInWeekends + HPlayInWorkingDays;
            int timeLeft = totalPlayTime - 30000;
            int timeNeeded = 30000 - totalPlayTime;
            if (totalPlayTime > 30000)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{timeLeft / 60} hours and {Math.Abs(timeNeeded % 60)} minutes more for play");
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{timeNeeded / 60} hours and {Math.Abs(timeNeeded % 60)} minutes less for play");
            }
        }
    }
}
