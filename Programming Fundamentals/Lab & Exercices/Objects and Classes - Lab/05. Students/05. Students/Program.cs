using System;
using System.Collections.Generic;

namespace _04
{
    class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Hometown { get; set; }


        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            List<Students> students = new List<Students>();

            while (comand != "end")
            {
                string[] information = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = information[0];
                string lastName = information[1];
                string age = information[2];
                string town = information[3];

                Students student = new Students();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.Hometown = town;

                students.Add(student);

                comand = Console.ReadLine();
            }

            string city = Console.ReadLine();
            foreach (Students student in students)
            {
                if (student.Hometown == city)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
}
