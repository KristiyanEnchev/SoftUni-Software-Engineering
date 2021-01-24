using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine().Split(", ");

            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (var item in people)
            {
                dic.Add(item, 0);
            }

            string patternDigit = @"[\W\d]";
            string patternLeters = @"[\WA-Za-z]";

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                string name = Regex.Replace(input, patternDigit, "");
                string distance = Regex.Replace(input, patternLeters, "");
                int sum = 0;

                foreach (var digit in distance)
                {
                    int currentDigit = int.Parse(digit.ToString());
                    sum += currentDigit;
                }

                if (dic.ContainsKey(name))
                {
                    dic[name] += sum;
                }

                input = Console.ReadLine();
            }

            int count = 1;

            foreach (var kvp in dic.OrderByDescending(x => x.Value))
            {
                string text = count == 1 ? "st" : count == 2 ? "nd" : "rd";

                Console.WriteLine($"{count++}{text} place: {kvp.Key}");

                if (count == 4)
                {
                    break;
                }
            }
        }
    }
}
