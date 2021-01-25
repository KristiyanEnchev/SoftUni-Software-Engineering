using System;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            string array = Console.ReadLine();

            string encription = string.Empty;

            for (int i = 0; i < array.Length; i++)
            {
                int newCharecter = array[i] + 3;
                char newChar = (char)newCharecter;
                encription += newChar;
            }

            Console.WriteLine(encription);
        }
    }
}
