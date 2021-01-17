using System;
using System.Collections.Generic;
using System.Linq;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            list.Reverse();
            List<string> final = new List<string>(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                List<string> numbers = list[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                for (int j = 0; j < numbers.Count; j++)
                {
                    final.Add(numbers[j]);
                }
            }

            Console.WriteLine(string.Join(" ", final));
        }
    }
}
