using System;
using System.Collections.Generic;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string comand = Console.ReadLine();
            while (comand != "End")
            {
                string[] input = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (input[0])
                {
                    case "Add":
                        list.Add(int.Parse(input[1]));
                        break;
                    case "Insert":
                        if (int.Parse(input[2]) >= 0 && int.Parse(input[2]) <= list.Count - 1)
                        {
                            list.Insert(int.Parse(input[2]), int.Parse(input[1]));
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Remove":
                        if (int.Parse(input[1]) >= 0 && int.Parse(input[1]) <= list.Count - 1)
                        {
                            list.RemoveAt(int.Parse(input[1]));
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Shift":
                        if (input[1] == "left")
                        {
                            int count = int.Parse(input[2]);
                            for (int i = 0; i < count; i++)
                            {
                                list.Add(list[0]);
                                list.RemoveAt(0);
                            }
                        }
                        else if (input[1] == "right")
                        {
                            int count = int.Parse(input[2]);
                            list.Reverse();
                            for (int i = 0; i < count; i++)
                            {
                                list.Add(list[0]);
                                list.RemoveAt(0);
                            }
                            list.Reverse();
                        }
                        break;
                }
                comand = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
