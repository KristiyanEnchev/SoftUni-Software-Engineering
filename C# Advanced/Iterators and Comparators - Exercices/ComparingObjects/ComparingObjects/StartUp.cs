using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<Person> people = new List<Person>();

            string comand = Console.ReadLine();
            while (comand != "END")
            {
                string[] info = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int age = int.Parse(info[1]);
                string town = info[2];

                people.Add(new Person(name, age, town));

                comand = Console.ReadLine();
            }

            int n = int.Parse(Console.ReadLine());
            Person personeToCompare = people[n -1];

            if (n < 0 || n >= people.Count)
            {
                Console.WriteLine("No matches");
                Environment.Exit(0);
            }

            int machCount = 0;
            foreach (var person in people)
            {
                if (person.CompareTo(personeToCompare) == 0)
                {
                    machCount++;
                }
            }

            if (machCount == 0)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{machCount} {people.Count - machCount} {people.Count}");
            }
        }
    }
}
