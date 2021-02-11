using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam_7_November
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> piratShips = Console.ReadLine()
                 .Split(">")
                 .Select(int.Parse)
                 .ToList();

            List<int> warShips = Console.ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToList();

            int maxhelth = int.Parse(Console.ReadLine());

            string comand = Console.ReadLine();
            while (comand != "Retire")
            {
                string[] input = comand.Split();

                if (input[0] == "Fire")
                {
                    int index = int.Parse(input[1]);
                    int damege = int.Parse(input[2]);
                    if (index >= 0 && index <= warShips.Count - 1)
                    {
                        warShips[index] -= damege;
                        if (warShips[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            Environment.Exit(0);
                        }
                    }
                }
                else if (input[0] == "Defend")
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);
                    int damege = int.Parse(input[3]);
                    if (startIndex >= 0 && startIndex <= piratShips.Count - 1 && endIndex >= 0 && endIndex <= piratShips.Count - 1)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            piratShips[i] -= damege;
                            if (piratShips[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                Environment.Exit(0);
                            }
                        }
                    }
                }
                else if (input[0] == "Repair")
                {
                    int index = int.Parse(input[1]);
                    int helth = int.Parse(input[2]);
                    if (index >= 0 && index <= piratShips.Count - 1)
                    {
                        piratShips[index] += helth;
                        if (piratShips[index] > maxhelth)
                        {
                            piratShips[index] = maxhelth;
                        }
                    }
                }
                else if (input[0] == "Status")
                {
                    int count = 0;
                    double needRepair = maxhelth * 0.20;
                    for (int i = 0; i < piratShips.Count; i++)
                    {
                        if (piratShips[i] < needRepair)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine($"{count} sections need repair.");
                }

                comand = Console.ReadLine();
            }
            Console.WriteLine($"Pirate ship status: {piratShips.Sum()}");
            Console.WriteLine($"Warship status: {warShips.Sum()}");
        }
    }
}
