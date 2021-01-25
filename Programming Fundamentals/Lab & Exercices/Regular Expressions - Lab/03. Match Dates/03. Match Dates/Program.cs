using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<day>\d{2})([\/.-])(?<mounth>[A-Z]{1}[a-z]{2})\1(?<year>\d{4})\b";

            string text = Console.ReadLine();

            MatchCollection colection = Regex.Matches(text, pattern);

            foreach (Match item in colection)
            {
                string day = item.Groups["day"].Value;
                string mounth = item.Groups["mounth"].Value;
                string year = item.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {mounth}, Year: {year}");
            }
        }
    }
}
