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
                .Split()
                .Select(int.Parse)
                .ToList();

            string comand = Console.ReadLine();
            while (comand != "end")
            {
                string[] input = comand.Split();
                switch (input[0])
                {
                    case "swap":
                        int num = list[int.Parse(input[1])];
                        list[int.Parse(input[1])] = list[int.Parse(input[2])];
                        list[int.Parse(input[2])] = num;
                        break;
                    case "multiply":
                        int indexOne = int.Parse(input[1]);
                        int indexTwo = int.Parse(input[2]);
                        int multiplyedNum = list[indexOne] * list[indexTwo];
                        list.RemoveAt(indexOne);
                        list.Insert(indexOne, multiplyedNum);
                        break;
                    case "decrease":
                        for (int i = 0; i < list.Count; i++)
                        {
                            list[i] -= 1;
                        }
                        break;
                }

                comand = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
