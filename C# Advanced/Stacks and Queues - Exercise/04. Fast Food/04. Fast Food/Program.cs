using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount = int.Parse(Console.ReadLine());

            var data = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(data);

            bool isComplete = true;

            if (queue.Any())
            {
                Console.WriteLine(queue.Max());
            }

            for (int i = 0; i < data.Length; i++)
            {
                int currentOrder = data[i];

                if (currentOrder <= amount)
                {
                    amount -= queue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(' ', queue)}");
                    isComplete = false;
                    break;
                }
            }

            if (isComplete)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}