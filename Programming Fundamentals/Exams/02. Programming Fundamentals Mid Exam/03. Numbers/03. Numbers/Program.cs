using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequance = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int avgSequance = sequance.Sum() / sequance.Count;

            List<int> newSequance = new List<int>();
            for (int i = 0; i < sequance.Count; i++)
            {
                if (avgSequance >= 0)
                {
                    if (sequance[i] > avgSequance)
                    {
                        newSequance.Add(sequance[i]);
                    }
                }
                else
                {
                    if (sequance[i] >= avgSequance)
                    {
                        newSequance.Add(sequance[i]);
                    }
                }
            }
            if (newSequance.Count == 0)
            {
                Console.WriteLine("No");
                Environment.Exit(0);
            }
            newSequance.Sort();
            newSequance.Reverse();
            if (newSequance.Count > 5)
            {
                newSequance.RemoveRange(5, newSequance.Count - 5);
                Console.WriteLine(string.Join(" ", newSequance));
            }
            else
            {
                Console.WriteLine(string.Join(" ", newSequance));
            }
        }
    }
}
