using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split()
                .Where(w => w.Length % 2 == 0)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, list));

        }
    }
}
