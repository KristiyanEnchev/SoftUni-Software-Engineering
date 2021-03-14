using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                people.Add(new Person(input[0], input[1], int.Parse(input[2])));
            }

            people = people
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.Age)
                .ToList();

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
