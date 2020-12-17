using System;
class Program
{
    static void Main(string[] args)
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        if (end <= start)
        {
            end = int.Parse(Console.ReadLine());
        }
        int magicNumber = int.Parse(Console.ReadLine());
        int count = 0;
        for (int i = start; i <= end; i++)
        {
            for (int j = start; j <= end; j++)
            {
                count++;
                if (i + j == magicNumber)
                {
                    Console.WriteLine($"Combination N:{count} ({i} + {j} = {magicNumber})");
                    return;
                }
            }
        }
        Console.WriteLine($"{count} combinations - neither equals {magicNumber}");
    }
}