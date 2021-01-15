using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            Dictionary<string, int> name = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string lower = word.ToLower();
                if (name.ContainsKey(lower))
                {
                    name[lower]++;
                }
                else
                {
                    name.Add(lower, 1);
                }
            }

            foreach (var item in name)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write(item.Key + " ");
                }
            }
        }
    }
}
