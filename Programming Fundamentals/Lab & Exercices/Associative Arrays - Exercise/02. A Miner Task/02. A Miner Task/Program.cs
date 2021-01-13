using System;
using System.Collections.Generic;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            string resources = Console.ReadLine();
            Dictionary<string, int> input = new Dictionary<string, int>();

            while (resources != "stop")
            {
                int cuantity = int.Parse(Console.ReadLine());

                if (!input.ContainsKey(resources))
                {
                    input.Add(resources, 0);
                }

                input[resources] += cuantity;

                resources = Console.ReadLine();
            }

            foreach (var item in input)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
