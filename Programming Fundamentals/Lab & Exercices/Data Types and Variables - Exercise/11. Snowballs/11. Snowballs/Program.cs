using System;
using System.Numerics;

namespace SnowBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            int snowballsMadeN = int.Parse(Console.ReadLine());
            BigInteger biggestSnowBall = 0;
            string result = string.Empty;

            for (int i = 0; i < snowballsMadeN; i++)
            {
                int snowballsSnow = int.Parse(Console.ReadLine());
                int snowballsTime = int.Parse(Console.ReadLine());
                int snowballsQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow((snowballsSnow / snowballsTime), snowballsQuality);

                if (snowballValue > biggestSnowBall)
                {
                    biggestSnowBall = snowballValue;
                    result = ($"{snowballsSnow} : {snowballsTime} = {snowballValue} ({snowballsQuality})");
                }
            }
            Console.WriteLine(result);
        }
    }
}