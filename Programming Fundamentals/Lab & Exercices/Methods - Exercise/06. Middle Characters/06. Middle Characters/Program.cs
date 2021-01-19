using System;

namespace ConsoleApp64
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            string middleChars = FidingMiddleChars(word);
            Console.WriteLine(middleChars);
        }

        public static string FidingMiddleChars(string word)
        {
            string newWord = string.Empty;

            for (int i = 0; i < word.Length / 2 + 1; i++)
            {
                char letter = word[i];
                if (word.Length % 2 == 0)
                {
                    if (i == word.Length / 2)
                    {
                        char letter2 = word[i - 1];
                        newWord += letter2;
                        newWord += letter;
                    }
                }
                else
                {
                    if (i == word.Length / 2)
                    {
                        newWord += word[i];
                    }
                }
            }

            return newWord;
        }
    }
}
