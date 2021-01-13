using System;
using System.Collections.Generic;
using System.Linq;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (comand != "end")
            {
                string[] cmd = comand.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string courceName = cmd[0];
                string studentName = cmd[1];

                if (!courses.ContainsKey(courceName))
                {
                    courses.Add(courceName, new List<string>());
                }
                courses[courceName].Add(studentName);

                comand = Console.ReadLine();
            }

            foreach (var item in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                foreach (var itemm in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {itemm}");
                }
            }
        }
    }
}
