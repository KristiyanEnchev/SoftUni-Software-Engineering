using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int inputNumber = int.Parse(Console.ReadLine());

        for (int i = 1; i <= inputNumber; i++)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            long num1 = long.Parse(input[0]);
            long num2 = long.Parse(input[1]);

            if (num1 > num2)
            {
                long sum = 0;
                while (num1 != 0)
                {
                    long digit = num1 % 10;
                    sum += digit;
                    num1 /= 10;
                }
                Console.WriteLine(Math.Abs(sum));
            }
            else
            {
                long sum = 0;
                while (num2 != 0)
                {
                    long digit = num2 % 10;
                    sum += digit;
                    num2 /= 10;
                }
                Console.WriteLine(Math.Abs(sum));
            }

        }
    }
}