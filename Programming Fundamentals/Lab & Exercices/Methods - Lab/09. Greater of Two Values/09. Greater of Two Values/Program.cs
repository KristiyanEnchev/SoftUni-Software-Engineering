using System;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine().ToLower();

            if (type == "string")
            {
                string one = Console.ReadLine();
                string two = Console.ReadLine();

                string max = Value(one, two);
                Console.WriteLine(max);
            }
            else if (type == "char")
            {
                char one = char.Parse(Console.ReadLine());
                char two = char.Parse(Console.ReadLine());

                char max = Value(one, two);
                Console.WriteLine(max);
            }
            else if (type == "int")
            {
                int one = int.Parse(Console.ReadLine());
                int two = int.Parse(Console.ReadLine());

                int max = Value(one, two);
                Console.WriteLine(max);
            }
        }

        static char Value(char ch1, char ch2)
        {
            if (ch1 > ch2)
            {
                return ch1;
            }
            else
            {
                return ch2;
            }
        }
        static int Value(int num1, int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }
        static string Value(string word1, string word2)
        {
            if (word1.CompareTo(word2) >= 0)
            {
                return word1;
            }
            else
            {
                return word2;
            }
        }
    }
}