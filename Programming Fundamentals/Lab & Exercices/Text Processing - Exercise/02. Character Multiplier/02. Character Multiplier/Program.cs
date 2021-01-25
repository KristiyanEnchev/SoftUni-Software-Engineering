using System;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split();

            string one = str[0];
            string two = str[1];

            string longest = one;
            string shorter = two;

            if (shorter.Length > longest.Length)
            {
                longest = two;
                shorter = one;
            }

            Console.WriteLine(Counter(longest, shorter));
        }

        public static double Counter(string longest, string shorter)
        {
            double total = 0;

            for (int i = 0; i < shorter.Length; i++)
            {
                total += longest[i] * shorter[i];
            }
            int left = shorter.Length;
            for (int i = left; i < longest.Length; i++)
            {
                total += longest[i];
            }

            return total;
        }
    }
}
