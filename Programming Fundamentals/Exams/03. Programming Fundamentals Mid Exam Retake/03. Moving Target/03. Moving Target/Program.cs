using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToList();
            if (list.Contains(0))
            {
                list.Remove(0);
            }
            string comand = Console.ReadLine();
            while (comand != "End")
            {
                string[] input = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (input[0])
                {
                    case "Shoot":
                        int index = int.Parse(input[1]);
                        int power = int.Parse(input[2]);
                        if (index >= 0 && index <= list.Count - 1)
                        {
                            list[index] -= power;
                            if (list[index] <= 0)
                            {
                                list.Remove(list[index]);
                            }
                        }
                        break;
                    case "Add":
                        int indexToAdd = int.Parse(input[1]);
                        int value = int.Parse(input[2]);
                        if (indexToAdd >= 0 && indexToAdd <= list.Count - 1)
                        {
                            list.Insert(indexToAdd, value);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");
                        }
                        break;
                    case "Strike":
                        int indexx = int.Parse(input[1]);
                        int radius = int.Parse(input[2]);
                        if (indexx - radius >= 0 && indexx + radius <= list.Count - 1)
                        {
                            list.RemoveRange(indexx - radius, 2 * radius + 1);
                        }
                        else
                        {
                            Console.WriteLine("Strike missed!");
                        }
                        break;
                }
                comand = Console.ReadLine();
            }

            Console.WriteLine(string.Join("|", list));
        }
    }
}
