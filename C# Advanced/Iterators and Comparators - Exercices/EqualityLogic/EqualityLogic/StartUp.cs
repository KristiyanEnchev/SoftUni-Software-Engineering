using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            SortedSet<Person> people = new SortedSet<Person>();
            HashSet<Person> people1 = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int age = int.Parse(info[1]);

                people.Add(new Person(name, age));
                people1.Add(new Person(name, age));
            }

            Console.WriteLine(people.Count);
            Console.WriteLine(people1.Count);
        }
    }
}
