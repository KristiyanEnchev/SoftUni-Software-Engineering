using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Rankin
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string comand = Console.ReadLine();
            while (comand != "end of contests")
            {
                string[] input = comand.Split(":");
                string contestName = input[0];
                string password = input[1];

                contests.Add(contestName, password);

                comand = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, double>> data = new Dictionary<string, Dictionary<string, double>>();

            string dataInput = Console.ReadLine();
            while (dataInput != "end of submissions")
            {
                string[] input = dataInput.Split("=>");
                string contestName = input[0];
                string password = input[1];
                string user = input[2];
                double points = double.Parse(input[3]);

                if (contests.ContainsKey(contestName))
                {
                    if (contests[contestName].Contains(password))
                    {
                        if (!data.ContainsKey(user))
                        {
                            data.Add(user, new Dictionary<string, double>());
                            data[user].Add(contestName, points);
                        }
                        else
                        {
                            if (!data[user].ContainsKey(contestName))
                            {
                                data[user].Add(contestName, points);
                            }
                            else
                            {
                                if (data[user][contestName] < points)
                                {
                                    data[user][contestName] = points;
                                }
                            }
                        }
                    }
                }

                dataInput = Console.ReadLine();
            }

            double bestPoints = 0;
            string person = string.Empty;

            foreach (var student in data)
            {
                if (student.Value.Values.Sum() > bestPoints)
                {
                    bestPoints = student.Value.Values.Sum();
                    person = student.Key;
                }
            }

            Console.WriteLine($"Best candidate is {person} with total {bestPoints} points.");
            Console.WriteLine("Ranking: ");
            foreach (var student in data.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);
                foreach (var itemm in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {itemm.Key} -> {itemm.Value}");
                }
            }
        }
    }
}
