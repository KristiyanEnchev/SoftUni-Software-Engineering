using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());

            double BGN = usd * 1.79549;

            Console.WriteLine(BGN);
        }
    }
}
