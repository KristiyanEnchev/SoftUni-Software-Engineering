using System;
using System.Linq;
using System.Collections.Generic;

namespace Exam_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> record = new Dictionary<string, List<int>>();

            string comand = Console.ReadLine();
            while (comand != "Log out")
            {
                string[] input = comand.Split(": ");
                string cmd = input[0];
                string userName = input[1];

                if (cmd == "New follower")
                {
                    if (!record.ContainsKey(userName))
                    {
                        record.Add(userName, new List<int>());
                        record[userName].Add(0);
                        record[userName].Add(0);
                    }
                }
                else if (cmd == "Like")
                {
                    int count = int.Parse(input[2]);

                    if (!record.ContainsKey(userName))
                    {
                        record.Add(userName, new List<int> { 0, 0 });
                        record[userName][0] = count;
                    }
                    else
                    {
                        record[userName][0] += count;
                    }
                }
                else if (cmd == "Comment")
                {
                    if (!record.ContainsKey(userName))
                    {
                        record.Add(userName, new List<int> { 0, 0 });
                        record[userName][1] = 1;
                    }
                    else
                    {
                        record[userName][1] += 1;
                    }
                }
                else if (cmd == "Blocked")
                {
                    if (record.ContainsKey(userName))
                    {
                        record.Remove(userName);
                    }
                    else
                    {
                        Console.WriteLine($"{userName} doesn't exist.");
                    }
                }

                comand = Console.ReadLine();
            }

            Console.WriteLine($"{record.Keys.Count} followers");

            foreach (var item in record.OrderByDescending(x => x.Value.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Sum()}");
            }
        }
    }
}
