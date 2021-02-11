using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine()
                .Split("|")
                .ToList();

            string comand = Console.ReadLine();
            while (comand != "Yohoho!")
            {
                string[] input = comand.Split();

                if (input[0] == "Loot")
                {
                    for (int i = 1; i < input.Length; i++)
                    {
                        if (!chest.Contains(input[i]))
                        {
                            chest.Insert(0, input[i]);
                        }
                    }
                }
                else if (input[0] == "Drop")
                {
                    int index = int.Parse(input[1]);
                    if (index >= 0 && index <= chest.Count - 1)
                    {
                        string item = chest[index];
                        chest.Add(item);
                        chest.RemoveAt(index);
                    }
                }
                else if (input[0] == "Steal")
                {
                    int count = int.Parse(input[1]);
                    List<string> temp = new List<string>();
                    if (count <= chest.Count)
                    {
                        while (count > 0)
                        {
                            temp.Insert(0, chest[chest.Count - 1]);
                            chest.RemoveAt(chest.Count - 1);
                            count--;
                        }
                        Console.WriteLine(string.Join(", ", temp));
                    }
                    else
                    {
                        while (chest.Count - 1 >= 0)
                        {
                            temp.Insert(0, chest[chest.Count - 1]);
                            chest.RemoveAt(chest.Count - 1);
                        }
                        Console.WriteLine(string.Join(", ", temp));
                    }
                }

                comand = Console.ReadLine();
            }

            double avgLenght = 0;
            for (int i = 0; i < chest.Count; i++)
            {
                avgLenght += chest[i].Length;
            }

            if (chest.Count <= 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                double avgCount = avgLenght / chest.Count;
                Console.WriteLine($"Average treasure gain: {avgCount:f2} pirate credits.");
            }
        }
    }
}
