using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> statistic = new Dictionary<string, Dictionary<string, int>>();

            string comand = Console.ReadLine();
            while (comand != "no more time")
            {
                string[] input = comand.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string contest = input[1];
                string person = input[0];
                int points = int.Parse(input[2]);

                if (!statistic.ContainsKey(contest))
                {
                    statistic[contest] = new Dictionary<string, int>();
                    statistic[contest].Add(person, points);
                }
                else
                {
                    if (!statistic[contest].ContainsKey(person))
                    {
                        statistic[contest].Add(person, points);
                    }
                    else
                    {
                        if (statistic[contest][person] < points)
                        {
                            statistic[contest][person] = points;
                        }
                    }
                }

                comand = Console.ReadLine();
            }
            Dictionary<string, int> stats = new Dictionary<string, int>();
            foreach (var contest in statistic)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                int count = 0;
                foreach (var man in contest.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    count++;
                    Console.WriteLine($"{count}. {man.Key} <::> {man.Value}");
                    if (!stats.ContainsKey(man.Key))
                    {
                        stats.Add(man.Key, man.Value);
                    }
                    else
                    {
                        stats[man.Key] += man.Value;
                    }
                }
            }

            stats = stats
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Individual standings:");
            int count1 = 0;
            foreach (var person in stats)
            {
                count1++;
                Console.WriteLine($"{count1}. {person.Key} -> {person.Value}");
            }
        }
    }
}
