using System;
using System.Linq;
using System.Collections.Generic;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            int valueToBeKilled = int.Parse(Console.ReadLine());
            int currentTread = 0;

            while (true)
            {
                int task = tasks.Peek();
                int thread = threads.Dequeue();
                currentTread = thread;

                if (task == valueToBeKilled)
                {
                    int[] array = new int[threads.Count + 1];
                    array[0] = thread;
                    for (int i = 1; i < array.Length; i++)
                    {
                        array[i] = threads.Dequeue();
                    }

                    foreach (var item in array)
                    {
                        threads.Enqueue(item);
                    }

                    break;
                }

                if (thread >= task)
                {
                    tasks.Pop();
                }
            }

            Console.WriteLine($"Thread with value {currentTread} killed task {valueToBeKilled}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
