using System;

namespace ConsoleApp56
{
    class Program
    {
        static void Main(string[] args)
        {
            int one = int.Parse(Console.ReadLine());
            int two = int.Parse(Console.ReadLine());
            int sum = one + two;
            int three = int.Parse(Console.ReadLine());
            int sumOfDivision = sum / three;
            int four = int.Parse(Console.ReadLine());
            int result = four * sumOfDivision;
            Console.WriteLine(result);
        }
    }
}
