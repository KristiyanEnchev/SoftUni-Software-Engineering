using System;

namespace ConsoleApp44
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                if (i == 1 || i == num)
                {
                    Console.Write("+" + " ");
                }
                else
                {
                    Console.Write("|" + " ");
                }
                for (int j = 2; j <= num; j++)
                {
                    if (j == num)
                    {
                        if (i == 1 || i == num)
                        {
                            Console.Write("+");
                        }
                        else
                        {
                            Console.Write("|");
                        }
                    }
                    else
                    {
                        Console.Write("-" + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
