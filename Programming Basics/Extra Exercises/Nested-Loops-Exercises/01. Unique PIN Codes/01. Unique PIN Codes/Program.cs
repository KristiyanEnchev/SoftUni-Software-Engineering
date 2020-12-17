using System;

namespace ConsoleApp44
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int thurd = int.Parse(Console.ReadLine());
            for (int i = 1; i <= first; i++)
            {
                for (int j = 1; j <= second; j++)
                {
                    for (int k = 1; k <= thurd; k++)
                    {
                        if (j == 2 || j == 3 || j == 5 || j == 7)
                        {
                            if (i % 2 == 0 && k % 2 == 0)
                            {
                                Console.WriteLine($"{i} {j} {k}");
                            }
                        }
                    }
                }
            }
        }
    }
}