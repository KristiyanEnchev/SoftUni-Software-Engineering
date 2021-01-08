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


            while (arr.Length != 1)
            {
                int[] arr2 = new int[arr.Length - 1];

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    arr2[i] = arr[i] + arr[i + 1];
                }

                arr = arr2;
            }

            Console.WriteLine(string.Join(' ', arr));
        }
    }
}
