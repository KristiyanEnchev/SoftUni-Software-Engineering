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
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            string comand = Console.ReadLine();
            while (comand != "Craft!")
            {
                string[] input = comand.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string inputComand = input[0];
                if (inputComand == "Collect")
                {
                    string item = input[1];
                    if (!list.Contains(item))
                    {
                        list.Add(item);
                    }
                }
                else if (inputComand == "Drop")
                {
                    string item = input[1];
                    if (list.Contains(item))
                    {
                        list.Remove(item);
                    }
                }
                else if (inputComand == "Renew")
                {
                    string item = input[1];
                    if (list.Contains(item))
                    {
                        list.Remove(item);
                        list.Add(item);
                    }
                }
                else if (inputComand == "Combine Items")
                {
                    string[] items = input[1].Split(":");
                    string olsdItem = items[0];
                    string newItem = items[1];
                    if (list.Contains(olsdItem))
                    {
                        int index = list.IndexOf(olsdItem);
                        list.Insert(index + 1, newItem);
                    }
                }

                comand = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
