using System;

namespace ConsoleApp44
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int row = 0; row <= num; row++)
            {
                for (int i = 1; i <= num - row; i++)
                {
                    Console.Write(" ");
                }
                for (int i = 1; i <= row; i++)
                {
                    Console.Write("*");
                }
                Console.Write(" ");
                Console.Write("|");
                Console.Write(" ");
                for (int i = 1; i <= row; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}