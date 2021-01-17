using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string comand = Console.ReadLine();
            while (comand != "end")
            {
                string[] input = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Add")
                {
                    if (int.Parse(input[1]) >= 0)
                    {
                        wagons.Add(int.Parse(input[1]));
                    }
                }
                else
                {
                    if (int.Parse(input[0]) >= 0)
                    {
                        for (int i = 0; i < wagons.Count; i++)
                        {
                            if (wagons[i] + int.Parse(input[0]) <= maxCapacity)
                            {
                                wagons[i] += int.Parse(input[0]);
                                break;
                            }
                        }
                    }
                }

                comand = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
