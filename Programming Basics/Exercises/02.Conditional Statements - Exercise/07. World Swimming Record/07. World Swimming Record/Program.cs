using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordSeconds = double.Parse(Console.ReadLine());
            double totalMeters = double.Parse(Console.ReadLine());
            double timeForOneMeter = double.Parse(Console.ReadLine());

            double totalSecondsForRecord = totalMeters * timeForOneMeter;
            double deley = Math.Floor(totalMeters / 15) * 12.5;

            double totalTime = totalSecondsForRecord + deley;
            if (totalTime < recordSeconds)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else
            {
                double need = totalTime - recordSeconds;
                Console.WriteLine($"No, he failed! He was {need:f2} seconds slower.");
            }
        }
    }
}
