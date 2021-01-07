using System;

namespace ConsoleApp56
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLinesToFowoll = int.Parse(Console.ReadLine());
            int sumOfASCIIOfLetters = 0;
            for (int i = 1; i <= numberOfLinesToFowoll; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                int numberOfLetter = letter;
                sumOfASCIIOfLetters += numberOfLetter;
            }
            Console.WriteLine($"The sum equals: {sumOfASCIIOfLetters}");
        }
    }
}
