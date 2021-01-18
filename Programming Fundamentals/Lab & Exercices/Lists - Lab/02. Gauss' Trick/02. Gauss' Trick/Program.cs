using System;
using System.Linq;
using System.Collections.Generic;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> sumEquals = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();
            int maxIndex = sumEquals.Count / 2;
            int originalnumber = sumEquals.Count;
            for (int i = 0; i < maxIndex; i++)
            {
                sumEquals[i] += sumEquals[sumEquals.Count - 1];
                sumEquals.Remove(sumEquals[sumEquals.Count - 1]);
            }

            Console.WriteLine(string.Join(" ", sumEquals));
        }
    }
}
