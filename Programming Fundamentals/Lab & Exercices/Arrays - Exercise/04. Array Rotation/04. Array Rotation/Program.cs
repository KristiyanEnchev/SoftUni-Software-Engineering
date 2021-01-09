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

            int rotationCount = int.Parse(Console.ReadLine());

            int[] newSequance = new int[array.Length];

            if (rotationCount > array.Length)
            {
                rotationCount = rotationCount - array.Length;
            }
            for (int i = rotationCount; i < array.Length; i++)
            {
                int num = array[i];
                newSequance[i - rotationCount] = num;
            }

            for (int i = 0; i < rotationCount; i++)
            {
                int num = array[i];
                newSequance[i + array.Length - rotationCount] = num;
            }

            Console.WriteLine(string.Join(' ', newSequance));
        }
    }
}
