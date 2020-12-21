using System;

namespace ConsoleApp34
{
    class Program
    {
        static void Main(string[] args)
        {
            double timeForShoot = double.Parse(Console.ReadLine());
            double shootingCount = double.Parse(Console.ReadLine());
            double timeForShooting = double.Parse(Console.ReadLine());
            double timeForPreparation = timeForShoot * 0.15;
            double time = shootingCount * timeForShooting + timeForPreparation;
            if (time <= timeForShoot)
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(timeForShoot - time)} minutes left!");
            }
            else
            {
                Console.WriteLine($"Time is up! To complete the movie you need {Math.Round(time - timeForShoot)} minutes.");
            }
        }
    }
}
