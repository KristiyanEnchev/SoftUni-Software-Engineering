using System;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            foreach (var item in input)
            {
                foreach (var letter in item)
                {
                    Console.Write(item);
                }
            }
        }
    }
}
