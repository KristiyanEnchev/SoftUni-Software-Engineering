using System;

namespace ConsoleApp33
{
    class Program
    {
        static void Main(string[] args)
        {
            int a1 = int.Parse(Console.ReadLine());
            int a2 = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            for (int i = a1; i <= a2 - 1; i++)
            {
                char letter = (char)i;
                if (i % 2 != 0)
                {
                    double total = 0;
                    for (int j = 1; j <= n - 1; j++)
                    {
                        for (int k = 1; k <= (n / 2) - 1; k++)
                        {
                            total = i + j + k;
                            if (total % 2 != 0)
                            {
                                num = i;
                                num2 = j;
                                num3 = k;
                                Console.WriteLine($"{letter}-{num2}{num3}{num}");
                            }
                        }
                    }
                }
            }
        }
    }
}
