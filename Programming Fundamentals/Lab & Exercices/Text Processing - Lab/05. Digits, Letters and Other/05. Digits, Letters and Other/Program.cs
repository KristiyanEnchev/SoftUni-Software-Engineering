using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            string digit = string.Empty;
            string letter = string.Empty;
            string elsee = string.Empty;

            foreach (var charecter in word)
            {
                char ch = charecter;

                if (ch >= '0' && ch <= '9')
                {
                    digit += charecter;
                }
                else if (ch >= 'a' && ch <= 'z' || ch >= 'A' && ch <= 'Z')
                {
                    letter += charecter;
                }
                else
                {
                    elsee += charecter;
                }
            }

            Console.WriteLine(digit);
            Console.WriteLine(letter);
            Console.WriteLine(elsee);
        }
    }
}
