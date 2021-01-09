using System;
using System.Linq;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string bigestNumbers = string.Empty;
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int num = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    int num2 = array[j];
                    if (num > num2)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                        break;
                    }
                    if (count == array.Length - (i + 1))
                    {
                        bigestNumbers += num + " ";
                        count = 0;
                    }
                }
                if (i == array.Length - 1)
                {
                    bigestNumbers += num + " ";
                }
            }

            Console.WriteLine(string.Join(" ", bigestNumbers));
        }
    }
}
