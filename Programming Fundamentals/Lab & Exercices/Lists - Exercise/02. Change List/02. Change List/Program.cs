using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> num = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string comand = Console.ReadLine();
            while (comand != "end")
            {
                string[] input = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (input[0])
                {
                    case "Delete":
                        for (int i = 0; i < num.Count; i++)
                        {
                            if (num[i] == int.Parse(input[1]))
                            {
                                num.RemoveAt(i);
                            }
                        }
                        break;
                    case "Insert":
                        int index = int.Parse(input[2]);
                        int number = int.Parse(input[1]);
                        if (index >= 0 && index <= num.Count - 1)
                        {
                            num.Insert(index, number);
                        }
                        else
                        {
                            num.Add(number);
                        }
                        break;
                }

                comand = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", num));
        }
    }
}
