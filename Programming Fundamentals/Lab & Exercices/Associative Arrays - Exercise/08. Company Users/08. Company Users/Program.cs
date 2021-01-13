using System;
using System.Collections.Generic;
using System.Linq;

namespace _09
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companys = new Dictionary<string, List<string>>();

            string comand = Console.ReadLine();
            while (comand != "End")
            {
                string[] input = comand.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string companyName = input[0];
                string employeId = input[1];

                if (!companys.ContainsKey(companyName))
                {
                    companys.Add(companyName, new List<string> { employeId });
                }
                else
                {
                    if (!companys[companyName].Contains(employeId))
                    {
                        companys[companyName].Add(employeId);
                    }
                }

                comand = Console.ReadLine();
            }

            foreach (var company in companys.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{company.Key}");
                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
