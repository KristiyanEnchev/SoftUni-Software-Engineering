using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp66
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] comand = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (comand[0].ToUpper() != "END")
            {
                switch (comand[0].ToUpper())
                {
                    case "ADD":
                        numbers.Add(int.Parse(comand[1]));
                        break;
                    case "REMOVE":
                        numbers.Remove(int.Parse(comand[1]));
                        break;
                    case "REMOVEAT":
                        numbers.RemoveAt(int.Parse(comand[1]));
                        break;
                    case "INSERT":
                        numbers.Insert(int.Parse(comand[2]), int.Parse(comand[1]));
                        break;
                }

                comand = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
