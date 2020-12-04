using System;

namespace ConsoleApp37
{
    class Program
    {
        static void Main(string[] args)
        {
            double kilometers = double.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            double taksi = 0;
            double buss = 0;
            double train = 0;
            if (kilometers < 20)
            {
                if (timeOfDay == "day")
                {
                    taksi = 0.70 + (0.79 * kilometers);
                }
                else if (timeOfDay == "night")
                {
                    taksi = 0.70 + (0.90 * kilometers);
                }
                Console.WriteLine($"{taksi:F2}");
            }
            else if (kilometers >= 20 && kilometers < 100)
            {
                if (timeOfDay == "day")
                {
                    taksi = 0.70 + (0.79 * kilometers);
                }
                else if (timeOfDay == "night")
                {
                    taksi = 0.70 + (0.90 * kilometers);
                }
                buss = 0.09 * kilometers;
                if (buss < taksi && buss != 0)
                {
                    Console.WriteLine($"{buss:F2}");
                }
                else
                {
                    Console.WriteLine($"{taksi:F2}");
                }
            }
            else if (kilometers >= 100)
            {
                if (timeOfDay == "day")
                {
                    taksi = 0.70 + (0.79 * kilometers);
                }
                else if (timeOfDay == "night")
                {
                    taksi = 0.70 + (0.90 * kilometers);
                }
                buss = 0.09 * kilometers;
                train = 0.06 * kilometers;
                if (train < buss && train < taksi && train != 0)
                {
                    Console.WriteLine($"{train:F2}");
                }
                else if (buss < taksi && buss != 0)
                {
                    Console.WriteLine($"{buss:F2}");
                }
                else
                {
                    Console.WriteLine($"{taksi:F2}");
                }
            }
        }
    }
}
