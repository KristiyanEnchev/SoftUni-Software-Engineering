using System;
using System.Text.RegularExpressions;

namespace Regexx
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"(\b[A-Z]{1}[a-z]+\s[A-Z][a-z]+\b)";

            MatchCollection colection = Regex.Matches(text, pattern);

            foreach (Match item in colection)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine();
        }
    }
}
