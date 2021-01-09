using System;
using System.Linq;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            int[] firstArray = new int[numberOfLines];
            int[] secondArray = new int[numberOfLines];

            for (int i = 0; i < numberOfLines; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    if (i % 2 == 0)
                    {
                        firstArray[i] = input[j];
                        secondArray[i] = input[j + 1];
                        break;
                    }
                    else
                    {
                        firstArray[i] = input[j + 1];
                        secondArray[i] = input[j];
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join(' ', firstArray));
            Console.WriteLine(string.Join(' ', secondArray));
        }
    }
}
