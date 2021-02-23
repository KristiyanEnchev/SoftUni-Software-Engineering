using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredictParty
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            List<string> namesList = Console.ReadLine()
                .Split()
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                List<string> tokens = command.Split().ToList();

                Predicate<string> predicate = GetPredicate(tokens[1], tokens[2]);

                if (tokens[0] == "Remove")
                {
                    namesList.RemoveAll(predicate);
                }
                else if (tokens[0] == "Double")
                {
                    List<string> matches = namesList.FindAll(predicate);
                    if (matches.Count > 0)
                    {
                        int index = namesList.FindIndex(predicate);
                        namesList.InsertRange(index, matches);
                    }

                }
            }

            if (namesList.Count != 0)
            {
                Console.WriteLine(string.Join(", ", namesList) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string command, string arg)
        {
            if (command == "StartsWith")
            {
                return (name) => name.StartsWith(arg);
            }
            else if (command == "EndsWith")
            {
                return (name) => name.EndsWith(arg);
            }
            else if (command == "Length")
            {
                return (name) => name.Length == int.Parse(arg);
            }
            else
            {
                return null; 
            }

        }
    }
}
