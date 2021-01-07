using System;

namespace ConsoleApp56
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLetter = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLetter; i++)
            {
                for (int j = 0; j < numberOfLetter; j++)
                {
                    for (int k = 0; k < numberOfLetter; k++)
                    {
                        char firstLetter = (char)('a' + i);
                        char secondLetter = (char)('a' + j);
                        char ThurdLetter = (char)('a' + k);
                        Console.WriteLine($"{firstLetter}{secondLetter}{ThurdLetter}");
                    }
                }
            }
        }
    }
}
