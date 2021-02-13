using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int n = data[0];
            int s = data[1];
            int x = data[2];

            int[] nubersInput = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> number = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                number.Push(nubersInput[i]);
            }

            for (int i = 0; i < s; i++)
            {
                number.Pop();
            }

            bool isFound = number.Contains(x);

            if (isFound)
            {
                Console.WriteLine("true");
            }
            else if (!number.Any())
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(number.Min());
            }
        }
    }
}
