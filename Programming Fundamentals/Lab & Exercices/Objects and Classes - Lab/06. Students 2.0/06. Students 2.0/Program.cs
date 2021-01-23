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

                if (IsExisting(students, firstName, lastName))
                {
                    Students student = GetStudent(students, firstName, lastName);
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.Hometown = town;
                }
                else
                {

                    Students student = new Students();
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.Hometown = town;

                    students.Add(student);
                }


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

        public static bool IsExisting(List<Students> students, string firstName, string lastName)
        {
            foreach (Students student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
        }

        public static Students GetStudent(List<Students> students, string firstName, string lastName)
        {
            Students existing = null;
            foreach (Students student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existing = student;
                }
            }
            return existing;
        }
    }
}
