using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp74
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] number = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> dic = new SortedDictionary<double, int>();

            foreach (var num in number)
            {
                if (dic.ContainsKey(num))
                {
                    dic[num]++;
                }
                else
                {
                    dic.Add(num, 1);
                }
            }

            foreach (var num in dic)
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }

        }
    }
}
