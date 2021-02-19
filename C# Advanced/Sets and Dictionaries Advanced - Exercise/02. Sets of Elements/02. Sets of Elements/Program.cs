using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ");
            int n = int.Parse(numbers[0]);
            int m = int.Parse(numbers[1]);

            var nSett = new HashSet<int>();
            var mSett = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                nSett.Add(input);
            }

            for (int i = 0; i < m; i++)
            {
                var input = int.Parse(Console.ReadLine());
                mSett.Add(input);
            }

            nSett.IntersectWith(mSett);

            Console.WriteLine(string.Join(" ", nSett));
        }
    }
}
