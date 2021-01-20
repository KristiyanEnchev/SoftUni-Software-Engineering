using System;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int repetitionCount = int.Parse(Console.ReadLine());

            Console.WriteLine(Return(word, repetitionCount));
        }

        private static string Return(string word, int repetition)
        {
            string result = "";

            for (int i = 0; i < repetition; i++)
            {
                Console.Write(word);
            }

            return result;
        }
    }
}
