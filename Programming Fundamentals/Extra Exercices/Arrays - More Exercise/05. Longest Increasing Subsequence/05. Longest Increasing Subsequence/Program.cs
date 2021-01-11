using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] len = new int[arr.Length];
            int[] prev = new int[arr.Length];

            int maxLen = 0;
            int index = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                len[i] = 1;
                prev[i] = -1;
                for (int j = 0; j <= i - 1; j++)
                {
                    if (arr[j] < arr[i] && len[j] + 1 > len[i])
                    {
                        len[i] = 1 + len[j];
                        prev[i] = j;
                    }
                }
                if (len[i] > maxLen)
                {
                    maxLen = len[i];
                    index = i;
                }
            }

            int[] LIS = new int[maxLen];
            int currentIndex = maxLen - 1;

            while (index != -1)
            {
                LIS[currentIndex] = arr[index];
                currentIndex--;
                index = prev[index];
            }

            Console.WriteLine(string.Join(" ", LIS));
        }
    }
}
