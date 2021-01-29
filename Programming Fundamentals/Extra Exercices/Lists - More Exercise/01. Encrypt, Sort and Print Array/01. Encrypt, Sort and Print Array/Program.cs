using System;
using System.Linq;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfString = int.Parse(Console.ReadLine());

            int vowelSum = 0;
            int consonantSum = 0;
            int nameSum = 0;
            int[] allNameSum = new int[numberOfString];

            for (int i = 0; i < numberOfString; i++)
            {
                string name = Console.ReadLine();

                for (int j = 0; j < name.Length; j++)
                {
                    char letter = name[j];
                    if (letter == 'a' || letter == 'A' || letter == 'u' || letter == 'U' || letter == 'e' ||
                        letter == 'E' || letter == 'i' || letter == 'I' || letter == 'o' || letter == 'O')
                    {
                        vowelSum += name[j] * name.Length;
                    }
                    else
                    {
                        consonantSum += name[j] / name.Length;
                    }
                }
                nameSum = vowelSum + consonantSum;
                allNameSum[i] = nameSum;
                vowelSum = 0;
                consonantSum = 0;
            }
            Array.Sort(allNameSum);
            for (int i = 0; i < allNameSum.Length; i++)
            {
                Console.WriteLine(allNameSum[i]);
            }
        }
    }
}
