using Microsoft.VisualBasic;
using System;

namespace ConsoleApp40
{
    class Program
    {
        static void Main(string[] args)
        {
            string mostPowerfulWord = "";
            double bestpoints = double.MinValue;
            while (true)
            {
                string word = Console.ReadLine();
                if (word == "End of words")
                {
                    break;
                }
                double asciiCount = 0;
                bool yes = false;
                double totalForAWord = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    char letter = (char)word[i];
                    int ASCII = letter;
                    asciiCount += ASCII;
                    if (i == 0)
                    {
                        switch (letter)
                        {
                            case 'a':
                            case 'A':
                            case 'e':
                            case 'E':
                            case 'i':
                            case 'I':
                            case 'o':
                            case 'O':
                            case 'u':
                            case 'U':
                            case 'y':
                            case 'Y':
                                yes = true;
                                break;
                        }
                    }
                }
                if (yes)
                {
                    totalForAWord = asciiCount * word.Length;
                }
                else
                {
                    totalForAWord = Math.Round(asciiCount / word.Length);
                }
                if (totalForAWord >= bestpoints)
                {
                    bestpoints = totalForAWord;
                    mostPowerfulWord = word;
                }
            }
            Console.WriteLine($"The most powerful word is {mostPowerfulWord} - {bestpoints}");
        }
    }
}
