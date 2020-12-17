using System;

namespace ConsoleApp44
{
    class Program
    {
        static void Main(string[] args)
        {
            char sector = char.Parse(Console.ReadLine());
            int row = int.Parse(Console.ReadLine());
            int oddSitCount = int.Parse(Console.ReadLine());
            int count = 0;
            for (char i = 'A'; i <= sector; i++)
            {
                for (int j = 1; j <= row; j++)
                {
                    if (j % 2 != 0)
                    {
                        for (int k = 97; k < 97 + oddSitCount; k++)
                        {
                            Console.WriteLine($"{i}{j}{(char)k}");
                            count++;
                        }
                    }
                    else
                    {
                        for (int t = 97; t < 97 + oddSitCount + 2; t++)
                        {
                            Console.WriteLine($"{i}{j}{(char)t}");
                            count++;
                        }
                    }
                }
                row++;
            }
            Console.WriteLine(count);
        }
    }
}