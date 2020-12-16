using System;
using System.Net.NetworkInformation;

namespace ConsoleApp44
{
    class Program
    {
        static void Main(string[] args)
        {
            int movesCount = int.Parse(Console.ReadLine());
            double total = 0;
            double firs = 0;
            double second = 0;
            double thurd = 0;
            double fourth = 0;
            double fifth = 0;
            double fail = 0;
            for (int i = 1; i <= movesCount; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num >= 0 && num <= 9)
                {
                    firs++;
                    total += num * 0.20;
                }
                else if (num >= 10 && num <= 19)
                {
                    second++;
                    total += num * 0.30;
                }
                else if (num >= 20 && num <= 29)
                {
                    thurd++;
                    total += num * 0.40;
                }
                else if (num >= 30 && num <= 39)
                {
                    fourth++;
                    total += 50;
                }
                else if (num >= 40 && num <= 50)
                {
                    fifth++;
                    total += 100;
                }
                else
                {
                    fail++;
                    total = total / 2;
                }
            }
            Console.WriteLine($"{total:f2}");
            Console.WriteLine($"From 0 to 9: {firs / movesCount * 100:f2}%");
            Console.WriteLine($"From 10 to 19: {second / movesCount * 100:f2}%");
            Console.WriteLine($"From 20 to 29: {thurd / movesCount * 100:f2}%");
            Console.WriteLine($"From 30 to 39: {fourth / movesCount * 100:f2}%");
            Console.WriteLine($"From 40 to 50: {fifth / movesCount * 100:f2}%");
            Console.WriteLine($"Invalid numbers: {fail / movesCount * 100:f2}%");
        }
    }
}
