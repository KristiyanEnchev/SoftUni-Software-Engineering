using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> num = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> sorted = num.OrderByDescending(n => n).ToList();

            if (sorted.Count > 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(sorted[i] + " ");
                }
            }
            else
            {
                Console.WriteLine(string.Join(" ", sorted));
            }
        }
    }
}
