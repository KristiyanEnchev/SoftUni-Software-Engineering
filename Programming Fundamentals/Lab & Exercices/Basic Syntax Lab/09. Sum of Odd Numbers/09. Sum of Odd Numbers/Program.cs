using System;

namespace ConsoleApp53
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int total = 0;
            for (int i = 1; i <= num * 2; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                    total += i;
                }
            }
            Console.WriteLine($"Sum: {total}");
        }
    }
}
