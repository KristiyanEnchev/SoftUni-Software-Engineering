using System;

namespace ConsoleApp44
{
    class Program
    {
        static void Main(string[] args)
        {
            int from = int.Parse(Console.ReadLine());
            int to = int.Parse(Console.ReadLine());
            for (int i = from; i <= to; i++)
            {
                for (int j = from; j <= to; j++)
                {
                    for (int k = from; k <= to; k++)
                    {
                        for (int l = from; l <= to; l++)
                        {
                            if (i % 2 == 0 && l % 2 != 0)
                            {
                                if (i > l)
                                {
                                    if ((j + k) % 2 == 0)
                                    {
                                        Console.Write($"{i}{j}{k}{l} ");
                                    }
                                }
                            }
                            else if (i % 2 != 0 && l % 2 == 0)
                            {
                                if (i > l)
                                {
                                    if ((j + k) % 2 == 0)
                                    {
                                        Console.Write($"{i}{j}{k}{l} ");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}