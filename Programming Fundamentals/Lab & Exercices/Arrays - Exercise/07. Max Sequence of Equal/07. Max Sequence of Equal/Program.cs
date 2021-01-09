using System;
using System.Linq;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int count = 1;
            int longestline = 1;
            int index = 1;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    count++;
                    if (count > longestline)
                    {
                        longestline = count;
                        index = arr[i];
                    }
                }
                else
                {
                    count = 1;
                }
            }
            for (int i = 0; i < longestline; i++)
            {
                Console.Write($"{index} ");
            }
        }
    }
}
