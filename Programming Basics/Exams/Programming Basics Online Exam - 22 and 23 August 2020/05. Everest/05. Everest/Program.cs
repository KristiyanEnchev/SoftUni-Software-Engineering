using System;

namespace ConsoleApp46
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 5364;
            int end = 8848;
            int dayCount = 1;
            while (true)
            {
                string actionTaken = Console.ReadLine();
                if (actionTaken == "END")
                {
                    break;
                }
                int metersTaken = int.Parse(Console.ReadLine());
                if (dayCount >= 5)
                {
                    break;
                }
                start += metersTaken;
                if (actionTaken == "Yes")
                {
                    dayCount++;
                }
                else if (actionTaken == "No")
                {
                    continue;
                }
                if (start >= end)
                {
                    break;
                }
            }
            if (start >= end)
            {
                Console.WriteLine($"Goal reached for {dayCount} days!");
            }
            else
            {
                Console.WriteLine("Failed!");
                Console.WriteLine($"{start}");
            }
        }
    }
}
