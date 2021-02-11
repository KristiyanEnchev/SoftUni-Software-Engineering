using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int points = 0;
            string comand = Console.ReadLine();
            while (comand != "Game over")
            {
                string[] input = comand.Split("@", StringSplitOptions.RemoveEmptyEntries);
                switch (input[0])
                {
                    case "Shoot Left":
                        int startIndexLeft = int.Parse(input[1]);
                        int lenghtLeft = int.Parse(input[2]);
                        if (startIndexLeft >= 0 && startIndexLeft <= targets.Count - 1)
                        {
                            while (lenghtLeft != 0)
                            {
                                if (startIndexLeft > 0)
                                {
                                    startIndexLeft--;
                                    lenghtLeft--;
                                }
                                else if (startIndexLeft == 0)
                                {
                                    startIndexLeft = targets.Count - 1;
                                    lenghtLeft--;
                                }
                            }
                            if (targets[startIndexLeft] < 5)
                            {
                                points += targets[startIndexLeft];
                                targets[startIndexLeft] = 0;
                            }
                            else
                            {
                                targets[startIndexLeft] -= 5;
                                points += 5;
                            }
                        }
                        break;
                    case "Shoot Right":
                        int startIndexRight = int.Parse(input[1]);
                        int lenghtRight = int.Parse(input[2]);
                        if (startIndexRight >= 0 && startIndexRight <= targets.Count - 1)
                        {
                            while (lenghtRight != 0)
                            {


                                if (startIndexRight < targets.Count - 1)
                                {
                                    startIndexRight++;
                                    lenghtRight--;
                                }
                                else if (startIndexRight == targets.Count - 1)
                                {
                                    startIndexRight = 0;
                                    lenghtRight--;
                                }
                            }
                            if (targets[startIndexRight] < 5)
                            {
                                points += targets[startIndexRight];
                                targets[startIndexRight] = 0;
                            }
                            else
                            {
                                targets[startIndexRight] -= 5;
                                points += 5;
                            }
                        }
                        break;
                    case "Reverse":
                        targets.Reverse();
                        break;
                }

                comand = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" - ", targets));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }
    }
}
