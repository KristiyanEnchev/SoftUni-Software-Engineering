using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int thurd = int.Parse(Console.ReadLine());

            int totalseconds = first + second + thurd;
            int totalMin = totalseconds / 60;
            int totalSec = totalseconds % 60;

            Console.WriteLine($"{totalMin}:{totalSec:d2}");
        }
    }
}
