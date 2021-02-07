using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int count = 0;
            string comand = Console.ReadLine();
            while (comand != "End")
            {
                int index = int.Parse(comand);
                if (index >= 0 && index <= list.Count - 1)
                {
                    int num = list[index];
                    list[index] = -1;
                    count++;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] > num && list[i] != -1)
                        {
                            list[i] -= num;
                        }
                        else if (list[i] <= num && list[i] != -1)
                        {
                            list[i] += num;
                        }
                    }
                }
                comand = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {count} -> {string.Join(" ", list)}");
        }
    }
}
