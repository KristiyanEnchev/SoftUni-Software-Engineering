using System;

namespace ConsoleApp44
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = int.Parse(Console.ReadLine());
            double fanCount = int.Parse(Console.ReadLine());
            double a = 0;
            double b = 0;
            double v = 0;
            double g = 0;
            for (int i = 1; i <= fanCount; i++)
            {
                char sector = char.Parse(Console.ReadLine());
                if (sector == 'A')
                {
                    a++;
                }
                else if (sector == 'B')
                {
                    b++;
                }
                else if (sector == 'V')
                {
                    v++;
                }
                else if (sector == 'G')
                {
                    g++;
                }
            }
            Console.WriteLine($"{a / fanCount * 100:f2}%");
            Console.WriteLine($"{b / fanCount * 100:f2}%");
            Console.WriteLine($"{v / fanCount * 100:f2}%");
            Console.WriteLine($"{g / fanCount * 100:f2}%");
            Console.WriteLine($"{fanCount / capacity * 100:f2}%");
        }
    }
}
