using System;

namespace ConsoleApp64
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = string.Empty;
            while ((comand = Console.ReadLine()) != "END")
            {
                string num = comand;
                string backwords = Exercice(num);
                if (backwords == num)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }

        public static string Exercice(string num)
        {
            string backwords = string.Empty;

            for (int i = num.Length - 1; i >= 0; i--)
            {
                backwords += num[i];
            }

            return backwords;
        }
    }
}