using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleWaiting = int.Parse(Console.ReadLine());

            List<int> wagonState = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            bool isPeopleWaiting = false;
            bool isTherePeopleAndSpots = false;
            for (int i = 0; i < wagonState.Count; i++)
            {
                if (peopleWaiting > 0)
                {
                    int currState = wagonState[i];
                    int state = currState;
                    if (currState >= 0 && currState < 4)
                    {
                        for (int j = currState; j < 4; j++)
                        {
                            currState++;
                            wagonState[i]++;
                            peopleWaiting--;
                            if (peopleWaiting <= 0)
                            {
                                isPeopleWaiting = true;
                                if (i == wagonState.Count - 1 && wagonState[i] == 4)
                                {
                                    isTherePeopleAndSpots = true;
                                }
                                break;
                            }
                            if (i == wagonState.Count - 1 && wagonState[i] == 4)
                            {
                                isTherePeopleAndSpots = true;
                            }
                        }
                    }
                }
                else
                {
                    isPeopleWaiting = true;
                    break;
                }
            }

            if (peopleWaiting > 0)
            {
                Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!");
                Console.WriteLine(string.Join(" ", wagonState));
            }
            else
            {
                if (isTherePeopleAndSpots)
                {
                    Console.WriteLine(string.Join(" ", wagonState));
                }
                else
                {
                    Console.WriteLine("The lift has empty spots!");
                    Console.WriteLine(string.Join(" ", wagonState));
                }
            }
        }
    }
}
