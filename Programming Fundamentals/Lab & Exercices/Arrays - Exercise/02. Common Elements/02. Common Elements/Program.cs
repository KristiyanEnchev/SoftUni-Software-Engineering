using System;
using System.Linq;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine()
                .Split().ToArray();

            string[] secondArray = Console.ReadLine()
                .Split().ToArray();

            string comonElemnts = string.Empty;

            for (int i = 0; i < secondArray.Length; i++)
            {
                string secondElement = secondArray[i];
                for (int j = 0; j < firstArray.Length; j++)
                {
                    string element = firstArray[j];
                    if (element == secondElement)
                    {
                        comonElemnts += element + " ";
                    }
                }
            }

            Console.WriteLine(comonElemnts);
        }
    }
}
