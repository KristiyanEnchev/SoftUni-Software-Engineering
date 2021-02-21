using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine().Split(" ");
                string name = personData[0];
                int age = int.Parse(personData[1]);

                Person currentperson = new Person(name, age);
                people.Add(currentperson);
            }

            List<Person> filtered = people.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();

            foreach (Person person in filtered)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
