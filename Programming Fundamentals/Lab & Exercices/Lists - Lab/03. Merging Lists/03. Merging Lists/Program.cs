using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> second = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> newList = new List<int>(first.Count + second.Count - 2);

            if (first.Count > second.Count)
            {
                for (int i = 0; i < second.Count; i++)
                {
                    newList.Add(first[i]);
                    newList.Add(second[i]);
                }
                for (int i = second.Count; i < first.Count; i++)
                {
                    newList.Add(first[i]);
                }
            }
            else
            {
                for (int i = 0; i < first.Count; i++)
                {
                    newList.Add(first[i]);
                    newList.Add(second[i]);
                }
                for (int i = first.Count; i < second.Count; i++)
                {
                    newList.Add(second[i]);
                }
            }

            Console.WriteLine(string.Join(" ", newList));
        }
    }
}
