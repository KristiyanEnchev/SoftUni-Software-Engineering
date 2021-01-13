using System;
using System.Collections.Generic;
using System.Linq;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> student = new Dictionary<string, int>();
            Dictionary<string, int> Submision = new Dictionary<string, int>();

            while (input != "exam finished")
            {
                string[] cmd = input.Split("-");
                string user = cmd[0];

                if (cmd.Length > 2)
                {
                    string language = cmd[1];
                    int points = int.Parse(cmd[2]);

                    if (!student.ContainsKey(user))
                    {
                        student.Add(user, points);
                    }
                    else
                    {
                        if (student[user] < points)
                        {
                            student[user] = points;
                        }
                    }

                    if (!Submision.ContainsKey(language))
                    {
                        Submision.Add(language, 0);
                    }

                    Submision[language]++;
                }
                else
                {
                    student.Remove(user);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");

            foreach (var students in student.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{students.Key} | {students.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var submission in Submision.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
