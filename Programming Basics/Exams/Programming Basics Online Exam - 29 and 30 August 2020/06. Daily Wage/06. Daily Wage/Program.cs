using System;

namespace ConsoleApp52
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowCount = int.Parse(Console.ReadLine());
            int placeCount = int.Parse(Console.ReadLine());
            double total = 0;
            for (int i = 1; i <= rowCount; i++)
            {
                double strawberryCount = 0;
                double blackberryCount = 0;
                if (i % 2 != 0)
                {
                    for (int j = 1; j <= placeCount; j++)
                    {
                        strawberryCount += 3.50;
                    }
                }
                else
                {
                    for (int j = 1; j <= placeCount; j++)
                    {
                        if (j % 3 != 0)
                        {
                            blackberryCount += 5.00;
                        }
                    }
                }
                total += strawberryCount + blackberryCount;
            }
            double finalTotal = total * 0.80;
            Console.WriteLine($"Total: {finalTotal:f2} lv.");
        }
    }
}
