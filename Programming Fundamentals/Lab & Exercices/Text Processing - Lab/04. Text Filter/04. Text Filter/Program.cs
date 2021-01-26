using System;
using System.Linq;
using System.Collections.Generic;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(", ")
                .ToList();

            string text = Console.ReadLine();

            foreach (var word in list)
            {
                string replacment = new string('*', word.Length);

                text = text.Replace(word, replacment);
            }

            Console.WriteLine(text);
        }
    }
}
