using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp77
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialStops = Console.ReadLine();

            string comand = Console.ReadLine();
            while (comand != "Travel")
            {
                string[] input = comand.Split(":");
                string cmd = input[0];

                if (cmd == "Add Stop")
                {
                    int index = int.Parse(input[1]);
                    string newStop = input[2];

                    if (index >= 0 && index <= initialStops.Length - 1)
                    {
                        initialStops = initialStops.Insert(index, newStop);
                    }

                    Console.WriteLine(initialStops);
                }
                else if (cmd == "Remove Stop")
                {
                    int start = int.Parse(input[1]);
                    int end = int.Parse(input[2]);

                    if (start >= 0 && start <= initialStops.Length - 1
                        && end >= 0 && end <= initialStops.Length - 1)
                    {
                        initialStops = initialStops.Remove(start, (end - start) + 1);
                    }

                    Console.WriteLine(initialStops);
                }
                else if (cmd == "Switch")
                {
                    string oldString = input[1];
                    string newString = input[2];

                    initialStops = initialStops.Replace(oldString, newString);

                    Console.WriteLine(initialStops);
                }

                comand = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {initialStops}");
        }
    }
}
