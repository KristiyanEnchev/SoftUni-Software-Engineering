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

            bool isChanged = false;

            while (comand[0].ToUpper() != "END")
            {
                switch (comand[0].ToUpper())
                {
                    case "ADD":
                        numbers.Add(int.Parse(comand[1]));
                        isChanged = true;
                        break;
                    case "REMOVE":
                        numbers.Remove(int.Parse(comand[1]));
                        isChanged = true;
                        break;
                    case "REMOVEAT":
                        numbers.RemoveAt(int.Parse(comand[1]));
                        isChanged = true;
                        break;
                    case "INSERT":
                        numbers.Insert(int.Parse(comand[2]), int.Parse(comand[1]));
                        isChanged = true;
                        break;
                    case "CONTAINS":
                        string answer = string.Empty;
                        Console.WriteLine(numbers.Contains(int.Parse(comand[1])) ? "Yes" : "No such number");
                        break;
                    case "PRINTEVEN":
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 == 0)));
                        break;
                    case "PRINTODD":
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 != 0)));
                        break;
                    case "GETSUM":
                        Console.WriteLine(numbers.Sum());
                        break;
                    case "FILTER":
                        string result = string.Empty;
                        switch (comand[1])
                        {
                            case "<":
                                result = string.Join(" ", numbers
                                    .Where(n => n < int.Parse(comand[2])));
                                break;
                            case ">":
                                result = string.Join(" ", numbers
                                    .Where(n => n > int.Parse(comand[2])));
                                break;
                            case ">=":
                                result = string.Join(" ", numbers
                                    .Where(n => n >= int.Parse(comand[2])));
                                break;
                            case "<=":
                                result = string.Join(" ", numbers
                                    .Where(n => n <= int.Parse(comand[2])));
                                break;
                        }

                        Console.WriteLine(result);
                        break;
                }

                comand = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
