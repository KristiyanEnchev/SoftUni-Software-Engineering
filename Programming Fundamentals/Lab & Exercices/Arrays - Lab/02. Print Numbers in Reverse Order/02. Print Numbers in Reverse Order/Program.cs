using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int[] arr = new int[numbers];

            for (int i = 0; i < numbers; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Join(' ', arr.Reverse()));
        }
    }
}
