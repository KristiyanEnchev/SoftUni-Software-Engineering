using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());

            if (num > 99 && num < 201 || num == 0)
            {

            }
            else
            {
                Console.WriteLine("invalid");
            }
        }
    }
}

