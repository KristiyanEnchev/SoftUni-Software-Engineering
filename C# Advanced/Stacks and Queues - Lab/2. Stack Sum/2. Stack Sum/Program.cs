using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < integers.Length; i++)
            {
                numbers.Push(integers[i]);
            }

            string comand = Console.ReadLine().ToLower();
            while (comand != "end")
            {
                string[] cmd = comand.Split(" ");
                string com = cmd[0];

                if (com == "add")
                {
                    numbers.Push(int.Parse(cmd[1]));
                    numbers.Push(int.Parse(cmd[2]));
                }
                else if (com == "remove")
                {
                    int numbersCount = int.Parse(cmd[1]);
                    if (numbers.Count >= numbersCount)
                    {
                        for (int i = 0; i < numbersCount; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }

                comand = Console.ReadLine().ToLower();
            }

            int sum = numbers.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
