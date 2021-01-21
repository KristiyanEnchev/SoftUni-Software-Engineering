using System;
using System.Collections.Generic;
using System.Linq;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PersonalInformation> persons = new List<PersonalInformation>();

            string comand = Console.ReadLine();
            while (comand != "End")
            {
                string[] input = comand.Split();
                string name = input[0];
                string iD = input[1];
                int age = int.Parse(input[2]);

                PersonalInformation info = new PersonalInformation();
                info.Name = name;
                info.ID = iD;
                info.Age = age;

                persons.Add(info);

                comand = Console.ReadLine();
            }
            persons = persons.OrderBy(x => x.Age).ToList();
            foreach (PersonalInformation person in persons)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }

    class PersonalInformation
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
}
