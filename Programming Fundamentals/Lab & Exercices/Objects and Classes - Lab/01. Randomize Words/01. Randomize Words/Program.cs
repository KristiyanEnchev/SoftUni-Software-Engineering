using System;
using System.Collections.Generic;
using System.Linq;


namespace Objects_and_Classes
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            List<string> wordsList = Console.ReadLine()
                .Split(' ')
                .ToList();
            int wordsCount = wordsList.Count;
            for (int i = 0; i < wordsCount - 1; i++)
            {
                int j = rand.Next(0, wordsCount);
                if (i != j)
                {
                    string old = wordsList[i];
                    wordsList[i] = wordsList[j];
                    wordsList[j] = old;
                }
            }

            foreach (string word in wordsList)
            {
                Console.WriteLine(word);
            }
        }
    }
}