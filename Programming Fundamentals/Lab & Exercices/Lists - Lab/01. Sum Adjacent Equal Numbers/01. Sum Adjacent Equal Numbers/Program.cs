using System;
using System.Collections.Generic;
using System.Linq;

namespace Lists_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> sumEquals = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            for (int i = 0; i < sumEquals.Count - 1; i++)
            {
                if (sumEquals[i] == sumEquals[i + 1])
                {
                    sumEquals[i] += sumEquals[i + 1];
                    sumEquals.RemoveAt(i + 1);
                    i = -1;
                }
            }
            Console.WriteLine(string.Join(" ", sumEquals));
        }
    }
}
