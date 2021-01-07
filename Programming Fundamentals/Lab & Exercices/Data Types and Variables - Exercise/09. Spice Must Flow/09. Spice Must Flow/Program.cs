using System;

namespace ConsoleApp56
{
    class Program
    {
        static void Main(string[] args)
        {
            double startingYield = double.Parse(Console.ReadLine());
            int dayCount = 0;
            double Yield = 0;
            if (startingYield >= 100)
            {
                while (startingYield >= 100)
                {
                    Yield += startingYield - 26;
                    dayCount++;
                    startingYield -= 10;
                }
                Console.WriteLine(dayCount);
                Console.WriteLine(Yield - 26);


            }
            else
            {
                Console.WriteLine(dayCount);
                Console.WriteLine(Yield);
            }
        }
    }
}
