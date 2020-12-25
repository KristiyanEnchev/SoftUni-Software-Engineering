using System;
using System.Threading;

namespace _10.Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesWalk = int.Parse(Console.ReadLine());
            int walksCount = int.Parse(Console.ReadLine());
            int caloriesForDay = int.Parse(Console.ReadLine());

            int totalMinutsForDay = minutesWalk * walksCount;
            int totalCaloriesUsed = totalMinutsForDay * 5;
            int caloriesNeeded = caloriesForDay / 2;
            if (caloriesNeeded <= totalCaloriesUsed)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {totalCaloriesUsed}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {totalCaloriesUsed}.");
            }
        }
    }
}