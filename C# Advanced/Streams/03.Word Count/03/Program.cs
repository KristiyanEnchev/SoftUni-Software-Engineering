using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            string expectedResult = Path.Combine("..", "..", "..", "expectedResult.txt");
            string[] words =   File.ReadAllLines("words.txt");
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            foreach (var item in words)
            {
                wordsCount.Add(item.ToLower(), 0);
            }

            string text = File.ReadAllText("text.txt").ToLower();

            string[] textWords = text.Split(new string[] { " ", ",", ".", "!", "?", "-" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in textWords)
            {
                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                }
            }

            Dictionary<string, int> sortedWords = wordsCount.OrderByDescending(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            List<string> outputLines = sortedWords.Select(kvp => $"{kvp.Key} - {kvp.Value}").ToList();

            File.WriteAllLines(expectedResult,outputLines);
        }
    }
}
