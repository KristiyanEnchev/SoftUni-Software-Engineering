using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] comand = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int index = 0;
            while (comand[0].ToLower() != "end")
            {
                switch (comand[0].ToLower())
                {
                    case "change":
                        int num = int.Parse(comand[1]);
                        int num2 = int.Parse(comand[2]);
                        index = list.IndexOf(num);
                        if (list.Contains(num))
                        {
                            list[index] = num2;
                        }
                        break;
                    case "hide":
                        index = list.IndexOf(int.Parse(comand[1]));
                        if (list.Contains(int.Parse(comand[1])))
                        {
                            list.RemoveAt(index);
                        }
                        break;
                    case "switch":
                        if (list.Contains(int.Parse(comand[1])) && list.Contains(int.Parse(comand[2])))
                        {
                            int indexFirst = list.IndexOf(int.Parse(comand[1]));
                            int indexSecond = list.IndexOf(int.Parse(comand[2]));

                            list[indexFirst] = int.Parse(comand[2]);
                            list[indexSecond] = int.Parse(comand[1]);
                        }
                        break;
                    case "insert":
                        index = int.Parse(comand[1]);
                        if (index >= 0 && index <= list.Count - 1)
                        {
                            list.Insert(index + 1, int.Parse(comand[2]));
                        }
                        break;
                    case "reverse":
                        list.Reverse();
                        break;
                }

                comand = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
