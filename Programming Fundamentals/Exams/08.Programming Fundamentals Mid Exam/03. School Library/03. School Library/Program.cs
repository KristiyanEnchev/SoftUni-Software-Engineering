using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split("&", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string comand = Console.ReadLine();
            while (comand != "Done")
            {
                string[] input = comand.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                switch (input[0])
                {
                    case "Add Book":
                        if (!list.Contains(input[1]))
                        {
                            list.Insert(0, input[1]);
                        }
                        break;
                    case "Take Book":
                        string name = input[1];
                        if (list.Contains(name))
                        {
                            list.Remove(name);
                        }
                        break;
                    case "Swap Books":
                        int indexOfFirs = list.IndexOf(input[1]);
                        int indexOfSecond = list.IndexOf(input[2]);
                        string nameOfFirst = input[1];
                        if (list.Contains(input[1]) && list.Contains(input[2]))
                        {
                            list[indexOfFirs] = input[2];
                            list[indexOfSecond] = nameOfFirst;
                        }
                        break;
                    case "Insert Book":
                        list.Add(input[1]);
                        break;
                    case "Check Book":
                        int index = int.Parse(input[1]);
                        if (index >= 0 && index <= list.Count - 1)
                        {
                            Console.WriteLine(list[index]);
                        }
                        break;
                }
                comand = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
