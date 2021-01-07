using System;

namespace ConsoleApp56
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberFromASCII = int.Parse(Console.ReadLine());
            int numberToASCII = int.Parse(Console.ReadLine());
            for (int i = numberFromASCII; i <= numberToASCII; i++)
            {
                char letter = (char)i;
                Console.Write($"{letter} ");
            }
        }
    }
}
