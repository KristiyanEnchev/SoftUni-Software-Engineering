using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberPattern = @"\d";
            string EmojiPatern = @"(:{2}|\*{2})[A-Z][a-z]{2,}\1";
            Regex numReg = new Regex(numberPattern);
            Regex emoji = new Regex(EmojiPatern);

            string text = Console.ReadLine();

            long maches = 1;
            numReg.Matches(text)
            .Select(x => x.Value)
            .Select(int.Parse)
            .ToList()
            .ForEach(x => maches *= x);

            Console.WriteLine($"Cool threshold: {maches}");

            var matches = emoji.Matches(text);
            int totalCount = matches.Count();

            List<string> coolEmoji = new List<string>();

            foreach (Match item in matches)
            {
                long coolIndex = item.Value.Substring(2, item.Value.Length - 4)
                     .ToCharArray()
                     .Sum(x => (int)x);
                if (coolIndex > maches)
                {
                    coolEmoji.Add(item.Value);
                }
            }

            Console.WriteLine($"{totalCount} emojis found in the text. The cool ones are:");

            foreach (var item in coolEmoji)
            {
                Console.WriteLine(item);
            }
        }
    }
}
