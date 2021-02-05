using System;
using System.Text.RegularExpressions;

namespace _02TaskRateake
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            //string pattern = @"([#?\|]+)(?<product>[A-Z][a-z]?[\w\s\w]+)\1(?<data>[\d]{2})\/[\d]{2}\/[\d]{2}\1(?<cal>\d+)\1";
            string pattern = @"([#?\|]+)(?<product>[A-Z][a-z]?[\w\s\w]+)\1(?<data>\d{2}\/\d{2}\/\d{2})\1(?<cal>\d+)\1";

            Regex regex = new Regex(pattern);
            MatchCollection mathes = regex.Matches(text);
            int sumCal = 0;

            foreach (Match item in mathes)
            {
                sumCal += int.Parse(item.Groups["cal"].Value);
            }

            int countDay = sumCal / 2000;

            Console.WriteLine($"You have food to last you for: {countDay} days!");

            foreach (Match kvp in mathes)
            {
                Console.WriteLine($"Item: {kvp.Groups["product"].Value}, Best before: {kvp.Groups["data"].Value}, Nutrition: {kvp.Groups["cal"].Value}");
            }
        }
    }
}
