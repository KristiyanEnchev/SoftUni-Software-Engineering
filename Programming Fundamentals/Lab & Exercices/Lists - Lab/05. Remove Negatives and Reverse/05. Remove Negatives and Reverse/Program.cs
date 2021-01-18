using System;
using System.Collections.Generic;
using System.Linq;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.RemoveAt(i);
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine("empty");
                        Environment.Exit(0);
                    }
                    i = -1;
                }
            }
            numbers.Reverse();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
