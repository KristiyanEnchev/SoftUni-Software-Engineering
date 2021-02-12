using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ");
            int n = int.Parse(Console.ReadLine());

            Queue<string> kids = new Queue<string>(names);
            int tossCount = 0;

            while (kids.Count > 1)
            {
                tossCount++;
                string kid = kids.Dequeue();
                if (tossCount % n == 0)
                {
                    Console.WriteLine($"Removed {kid}");
                    tossCount = 0;
                }
                else
                {
                    kids.Enqueue(kid);
                }
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
