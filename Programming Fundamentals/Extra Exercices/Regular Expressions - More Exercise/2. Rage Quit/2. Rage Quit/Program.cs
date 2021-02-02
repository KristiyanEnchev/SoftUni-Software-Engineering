using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Rage_Quit___third_try
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToUpper();

            StringBuilder sb = new StringBuilder();

            string[] symbolArr = text.Split(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }, StringSplitOptions.RemoveEmptyEntries);

            MatchCollection matches = Regex.Matches(text, @"[\d]+");

            int[] digits = new int[matches.Count];

            int count = 0;

            foreach (Match digit in matches)
            {
                digits[count] = int.Parse(digit.Value);
                count++;
            }

            for (int i = 0; i < digits.Length; i++)
            {
                int countOfRepeats = digits[i];

                for (int z = 0; z < countOfRepeats; z++)
                {
                    sb.Append(symbolArr[i]);
                }
            }

            char[] uniqueSymbols = sb.ToString().Distinct().ToArray();

            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Length}");

            Console.WriteLine(sb);
        }
    }
}