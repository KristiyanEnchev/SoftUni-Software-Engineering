using System;

namespace ConsoleApp64
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());

            double sumOfFirstFactorial = FactorilSum(numOne);
            double sumOfSecondFactorial = FactorilSum(numTwo);
            double sumOfFactorials = sumOfFirstFactorial / sumOfSecondFactorial;

            Console.WriteLine($"{sumOfFactorials:f2}");
        }

        public static double FactorilSum(int number)
        {
            double result = 1;
            while (number != 1)
            {
                result = result * number;
                number = number - 1;
            }
            return result;
        }
    }
}