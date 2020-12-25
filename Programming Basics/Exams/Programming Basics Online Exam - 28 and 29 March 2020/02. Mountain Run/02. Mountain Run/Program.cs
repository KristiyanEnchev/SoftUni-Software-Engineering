using System;

class Program
{
    static void Main(string[] args)
    {
        double recordInSeconds = double.Parse(Console.ReadLine());
        double recordInMeters = double.Parse(Console.ReadLine());
        double timeForOneMeter = double.Parse(Console.ReadLine());

        double second = recordInMeters * timeForOneMeter;
        double delay = Math.Floor(recordInMeters / 50) * 30;

        double totalTime = second + delay;
        if (totalTime >= recordInSeconds)
        {
            Console.WriteLine($"No! He was {totalTime - recordInSeconds:f2} seconds slower.");
        }
        else
        {
            Console.WriteLine($" Yes! The new record is {totalTime:f2} seconds.");
        }
    }
}
