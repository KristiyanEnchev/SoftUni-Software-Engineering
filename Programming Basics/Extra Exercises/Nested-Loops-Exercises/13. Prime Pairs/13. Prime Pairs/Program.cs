using System;

class Program
{
    static void Main(string[] args)
    {
        int firstStart = int.Parse(Console.ReadLine());
        int secondStart = int.Parse(Console.ReadLine());
        int maxFirt = int.Parse(Console.ReadLine());
        int maxSecond = int.Parse(Console.ReadLine());
        for (int i = firstStart; i <= firstStart + maxFirt; i++)
        {
            for (int j = secondStart; j <= secondStart + maxSecond; j++)
            {
                if (i % 2 != 0 && i % 3 != 0 && i % 5 != 0 && i % 7 != 0 && j % 2 != 0 && j % 3 != 0 && j % 5 != 0 && j % 7 != 0)
                {
                    Console.WriteLine($"{i}{j}");
                }
            }
        }
    }
}
