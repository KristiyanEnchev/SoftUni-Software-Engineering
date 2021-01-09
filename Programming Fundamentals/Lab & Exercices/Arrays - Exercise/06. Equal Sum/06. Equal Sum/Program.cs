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

            int index = 0;
            int sumRight = 0;
            int sumLeft = 0;
            bool isTrue = false;

            for (int i = 0; i < arr.Length; i++)
            {
                int num = arr[i];
                for (int k = i + 1; k < arr.Length; k++)
                {
                    int num1 = arr[k];
                    sumRight += arr[k];
                }
                for (int j = i - 1; j >= 0; j--)
                {
                    int num3 = arr[j];
                    sumLeft += arr[j];
                }
                if (sumLeft == sumRight)
                {
                    index = i;
                    isTrue = true;
                    break;
                }
                else
                {
                    sumLeft = 0;
                    sumRight = 0;
                }
            }
            if (isTrue)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
