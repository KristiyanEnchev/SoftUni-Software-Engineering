using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            List<int> divaders = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> numbers = Enumerable.Range(1, end).ToList();

            foreach (var num in numbers)
            {
                if (divaders.All(d => num % d == 0))
                {
                    Console.Write(num + " ");
                }
            }

        }
    }
}
