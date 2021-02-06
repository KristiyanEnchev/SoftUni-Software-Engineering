using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            //string pattern = @"([=]|[\/])(?<name>[A-Z]{1}[A-Za-z]+)\1";
            string pattern = @"([=]|[\/])(?<name>[A-Z]{1}[A-Za-z]{2,})\1";

            Regex regex = new Regex(pattern);

            List<string> locations = new List<string>();

            foreach (Match item in regex.Matches(input))
            {
                locations.Add(item.Groups[2].Value);
            }

            int points = 0;

            foreach (var item in locations)
            {
                points += item.Length;
            }

            Console.Write("Destinations: ");
            Console.Write(string.Join(", ", locations));
            Console.WriteLine();
            Console.WriteLine($"Travel Points: {points}");
        }
    }
}
