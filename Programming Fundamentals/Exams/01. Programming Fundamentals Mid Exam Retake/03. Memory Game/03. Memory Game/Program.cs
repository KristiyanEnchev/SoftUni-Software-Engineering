using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sequance = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string comand = Console.ReadLine();
            int count = 0;
            while (comand != "end")
            {
                string[] input = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                count++;
                int indexOne = int.Parse(input[0]);
                int indexTwo = int.Parse(input[1]);
                if (indexOne >= 0 && indexOne <= sequance.Count - 1 && indexTwo >= 0 && indexTwo <= sequance.Count - 1)
                {
                    if (sequance[indexOne] == sequance[indexTwo])
                    {
                        string num = sequance[indexOne];
                        if (indexOne == 0)
                        {
                            sequance.RemoveAt(indexOne);
                            sequance.RemoveAt(indexTwo - 1);
                        }
                        else
                        {
                            sequance.RemoveAt(indexOne);
                            sequance.RemoveAt(indexTwo);
                        }

                        Console.WriteLine($"Congrats! You have found matching elements - {num}!");
                        if (sequance.Count == 0)
                        {
                            Console.WriteLine($"You have won in {count} turns!");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                        comand = Console.ReadLine();
                        continue;
                    }
                }
                else
                {
                    int indexToAdd = (sequance.Count) / 2;
                    sequance.Insert(indexToAdd, "-" + count + "a");
                    sequance.Insert(indexToAdd, "-" + count + "a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }

                comand = Console.ReadLine();
            }
            if (sequance.Count - 1 != 0)
            {
                Console.WriteLine($"Sorry you lose :(");
                Console.WriteLine(string.Join(" ", sequance));
            }
        }
    }
}
