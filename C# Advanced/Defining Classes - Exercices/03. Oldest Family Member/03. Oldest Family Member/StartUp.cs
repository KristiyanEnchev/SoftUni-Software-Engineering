using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine().Split(" ");
                string name = personData[0];
                int age = int.Parse(personData[1]);

                Person currentPerson = new Person(name, age);
                family.AddMember(currentPerson);
            }

            Person oldestMember = family.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}
