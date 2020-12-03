using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());
            min += 15;
            if (min >= 60)
            {
                min %= 60;
                h += 1;
            }
            if (h >= 24)
            {
                h = 0;
            }
            Console.WriteLine($"{h}:{min:d2}");
        }
    }
}
