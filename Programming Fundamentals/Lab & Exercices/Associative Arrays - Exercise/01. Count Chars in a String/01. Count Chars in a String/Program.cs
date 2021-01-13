using System;
using System.Collections.Generic;

namespace Assosiate_Arrays_Exercice
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Dictionary<char, int> occurences = new Dictionary<char, int>();

            foreach (var letter in input)
            {
                if (letter != ' ')
                {
                    if (!occurences.ContainsKey(letter))
                    {
                        occurences.Add(letter, 0);
                    }
                    occurences[letter]++;
                }
            }

            foreach (var charecters in occurences)
            {
                char key = charecters.Key;
                int value = charecters.Value;

                Console.WriteLine($"{key} -> {value}");
            }
        }
    }
}
