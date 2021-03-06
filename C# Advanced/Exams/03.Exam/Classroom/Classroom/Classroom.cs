using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> data;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            data = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }

        public string RegisterStudent(Student student)
        {
            if (data.Count < Capacity)
            {
                data.Add(student);

                return $"Added student {student.FirstName} {student.LastName}";
            }

            return $"No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = data.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);

            if (student == null)
            {
                return $"Student not found";
            }

            data.Remove(student);
            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            Student student = data.FirstOrDefault(p => p.Subject == subject);

            if (student == null)
            {
                return "No students enrolled for the subject";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var studen in data)
            {
                if (studen.Subject == subject)
                {
                    sb.AppendLine($"{studen.FirstName} {studen.LastName}");
                }
            }
            return sb.ToString().Trim();
        }

        public int GetStudentsCount()
        {
            return data.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = data.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);

            return student;
        }
    }
}
