using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split(" ");

            Returnn(array);

        }

        public static void Returnn(string[] arr)
        {
            foreach (var item in arr)
            {
                if (item.Any(char.IsUpper))
                {
                    Console.WriteLine(item);
                }
            }

        }
    }
}
