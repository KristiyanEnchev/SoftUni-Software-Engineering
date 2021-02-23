using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(" ")
                .ToList();

            List<string> newNAmes = names.Select(name => $"Sir {name}").ToList();

            Action<List<string>> printName = n => Console.WriteLine(string.Join(Environment.NewLine, n));

            printName(newNAmes);
        }
    }
}
