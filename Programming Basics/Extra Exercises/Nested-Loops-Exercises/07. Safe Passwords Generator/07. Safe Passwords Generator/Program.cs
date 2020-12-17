using System;

class Program
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int maxPasswordCount = int.Parse(Console.ReadLine());
        int minX = 35;
        int minY = 64;
        int count = 0;
        while (minX <= 55)
        {
            while (minY <= 96)
            {
                for (int i = 1; i <= a; i++)
                {
                    for (int j = 1; j <= b; j++)
                    {
                        Console.Write($"{(char)minX}{(char)minY}{i}{j}{(char)minY}{(char)minX}|");
                        count++;
                        minX++;
                        minY++;
                        if (maxPasswordCount == count || i == a && j == b)
                        {
                            return;
                        }
                        if (minX > 55)
                        {
                            minX = 35;
                        }
                        if (minY > 96)
                        {
                            minY = 64;
                        }
                    }
                }
            }
        }
    }
}