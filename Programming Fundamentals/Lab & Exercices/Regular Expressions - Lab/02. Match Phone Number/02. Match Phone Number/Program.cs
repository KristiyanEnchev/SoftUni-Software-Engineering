using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([+][359]+[-][2])([-]\d{3})([-]\d{4}\b)|([+][359]+[ ][2])([ ]\d{3})([ ]\d{4}\b)";

            string text = Console.ReadLine();

            MatchCollection colection = Regex.Matches(text, pattern);

            string[] machText = colection.Select(X => X.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(", ", machText));
        }
    }
}
