using System;

namespace ConsoleApp44
{
    class Program
    {
        static void Main(string[] args)
        {
            int men = int.Parse(Console.ReadLine());
            int women = int.Parse(Console.ReadLine());
            int maxCapacity = int.Parse(Console.ReadLine());
            int count = 0;
            for (int j = 1; j <= men; j++)
            {
                for (int k = 1; k <= women; k++)
                {
                    Console.Write($"({j} <-> {k}) ");
                    count++;
                    if (count == maxCapacity)
                    {
                        break;
                    }
                    if (j == men && k == women)
                    {
                        break;
                    }
                }
                if (count == maxCapacity)
                {
                    break;
                }
            }
        }
    }
}