using System;

namespace ConsoleApp36
{
    class Program
    {
        static void Main(string[] args)
        {
            double numCount = double.Parse(Console.ReadLine());
            if (numCount < 1 || numCount > 1000)
            {
                numCount = double.Parse(Console.ReadLine());
            }
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            for (int i = 1; i <= numCount; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if (num % 2 == 0)
                {
                    p1++;
                }
                if (num % 3 == 0)
                {
                    p2++;
                }
                if (num % 4 == 0)
                {
                    p3++;
                }
            }
            Console.WriteLine($"{p1 / numCount * 100:f2}%");
            Console.WriteLine($"{p2 / numCount * 100:f2}%");
            Console.WriteLine($"{p3 / numCount * 100:f2}%");
        }
    }
}
