using System;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] mass = Console.ReadLine().Split("\\");
            int index = mass.Length - 1;
            string[] last = mass[index].Split(".");

            Console.WriteLine($"File name: {last[0]}");
            Console.WriteLine($"File extension: {last[1]}");
        }
    }
}
