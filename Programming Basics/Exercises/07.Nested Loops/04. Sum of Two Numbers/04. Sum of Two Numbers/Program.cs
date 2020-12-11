using System;
class Program
{
    static void Main(string[] args)
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        int magicNum = int.Parse(Console.ReadLine());
        int combinationCount = 0;
        bool found = false;
        int x = 0;
        int y = 0;
        for (int i = start; i <= end; i++)
        {
            for (int j = start; j <= end; j++)
            {
                combinationCount++;
                if (i + j == magicNum)
                {
                    x = i;
                    y = j;
                    found = true;
                    break;
                }
            }
            if (found)
            {
                break;
            }
        }
        if (found)
        {
            Console.WriteLine($"Combination N:{combinationCount} ({x} + {y} = {magicNum})");

        }
        else
        {
            Console.WriteLine($"{combinationCount} combinations - neither equals {magicNum}");
        }
    }
}
