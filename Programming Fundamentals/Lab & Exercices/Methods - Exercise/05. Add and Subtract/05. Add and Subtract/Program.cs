using System;

namespace ConsoleApp64
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int thurd = int.Parse(Console.ReadLine());

            int sum = AddingFirstAndSecond(first, second) - thurd;
            Console.WriteLine(sum);
        }

        public static int AddingFirstAndSecond(int first, int second)
        {
            int sum = first + second;

            return sum;
        }
    }
}
