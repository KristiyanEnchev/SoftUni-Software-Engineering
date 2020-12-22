using System;
using System.Net;
using System.Runtime;

namespace ConsoleApp42
{
    class Program
    {
        static void Main(string[] args)
        {
            int record = int.Parse(Console.ReadLine());
            int start = record - 30;
            int jumpCount = 0;
            int failCount = 0;
            while (start <= record)
            {
                int jusmp = int.Parse(Console.ReadLine());
                jumpCount++;
                if (jusmp > start)
                {
                    start += 5;
                    failCount = 0;
                }
                else
                {
                    failCount++;
                }
                if (failCount >= 3)
                {
                    break;
                }
            }
            if (start <= record)
            {
                Console.WriteLine($"Tihomir failed at {start}cm after {jumpCount} jumps.");
            }
            else
            {
                Console.WriteLine($"Tihomir succeeded, he jumped over {record}cm after {jumpCount} jumps.");
            }
        }
    }
}
