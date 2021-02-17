using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

            Dictionary<double, int> times = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!times.ContainsKey(numbers[i]))
                {
                    times.Add(numbers[i], 0);
                }

                times[numbers[i]]++;
            }

            foreach (var time in times)
            {
                Console.WriteLine($"{time.Key} - {time.Value} times");
            }
        }
    }
}
