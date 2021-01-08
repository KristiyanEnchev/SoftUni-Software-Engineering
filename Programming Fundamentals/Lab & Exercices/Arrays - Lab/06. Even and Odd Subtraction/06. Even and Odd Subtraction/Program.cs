using System;
using System.Linq;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int evenNumbers = 0;
            int oddNumberst = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    evenNumbers += arr[i];
                }
                else
                {
                    oddNumberst += arr[i];
                }
            }

            Console.WriteLine(evenNumbers - oddNumberst);
        }
    }
}

