using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam_prep_5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split("!")
                .ToList();

            string comand = Console.ReadLine();
            while (comand != "Go Shopping!")
            {
                string[] input = comand.Split();
                string currComand = input[0];
                string item = input[1];
                switch (currComand)
                {
                    case "Urgent":
                        if (!list.Contains(item))
                        {
                            list.Insert(0, item);
                        }
                        break;
                    case "Unnecessary":
                        if (list.Contains(item))
                        {
                            list.Remove(item);
                        }
                        break;
                    case "Correct":
                        string newItem = input[2];
                        if (list.Contains(item))
                        {
                            int index = list.IndexOf(item);
                            list.Remove(item);
                            list.Insert(index, newItem);
                        }
                        break;
                    case "Rearrange":
                        if (list.Contains(item))
                        {
                            list.Remove(item);
                            list.Add(item);
                        }
                        break;
                }
                comand = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
