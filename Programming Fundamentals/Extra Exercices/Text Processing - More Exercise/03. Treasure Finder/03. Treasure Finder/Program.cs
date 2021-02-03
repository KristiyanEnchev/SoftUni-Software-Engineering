using System;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string comand = Console.ReadLine();

            while (comand != "find")
            {
                string hiddenMassage = HiddenMassage(array, comand);

                string type = FindTypeOfTresure(hiddenMassage);
                string cordinates = FindCordinatesOfTresure(hiddenMassage);

                Console.WriteLine($"Found {type} at {cordinates}");

                comand = Console.ReadLine();
            }
        }

        public static string HiddenMassage(int[] array, string massege)
        {
            int index = 0;
            string newString = string.Empty;

            for (int i = 0; i < massege.Length; i++)
            {
                char ch = massege[i];
                int num = ch;

                if (i % array.Length == 0)
                {
                    index = 0;
                }
                num -= array[index];
                index++;

                newString += (char)num;
            }

            return newString;
        }

        public static string FindTypeOfTresure(string hiddenMassage)
        {
            string type = new string(hiddenMassage.SkipWhile(c => c != '&')
                       .Skip(1)
                       .TakeWhile(c => c != '&')
                       .ToArray()).Trim();

            return type;
        }

        public static string FindCordinatesOfTresure(string hiddenTresure)
        {
            string cordinates = new string(hiddenTresure.SkipWhile(c => c != '<')
                       .Skip(1)
                       .TakeWhile(c => c != '>')
                       .ToArray()).Trim();

            return cordinates;
        }
    }
}
