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
                .Split("@")
                .Select(int.Parse)
                .ToList();

            string comand = Console.ReadLine();
            int index = 0;
            List<int> already = new List<int>();
            while (comand != "Love!")
            {
                string[] input = comand.Split();
                int lenght = int.Parse(input[1]);
                index += lenght;

                if (index > list.Count - 1)
                {
                    index = 0;
                }

                if (list[index] == 0)
                {
                    Console.WriteLine($"Place {index} already had Valentine's day.");

                    comand = Console.ReadLine();
                    continue;
                }

                list[index] -= 2;

                if (list[index] == 0)
                {
                    Console.WriteLine($"Place {index} has Valentine's day.");
                }
                comand = Console.ReadLine();
            }
            int houseCount = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > 0)
                {
                    houseCount++;
                }
            }
            Console.WriteLine($"Cupid's last position was {index}.");
            if (houseCount <= 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {houseCount} places.");
            }
        }
    }
}
