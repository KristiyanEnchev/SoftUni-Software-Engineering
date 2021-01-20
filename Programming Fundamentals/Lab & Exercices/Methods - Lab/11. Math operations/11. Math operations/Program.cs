using System;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            double numOne = double.Parse(Console.ReadLine());
            string operatior = Console.ReadLine();
            double numTwo = double.Parse(Console.ReadLine());

            double result = Operation(numOne, operatior, numTwo);
            Console.WriteLine(result);
        }

        static double Operation(double num1, string operatorr, double num2)
        {
            double result = 0;
            if (operatorr == "*")
            {
                result = num1 * num2;
            }
            else if (operatorr == "/")
            {
                result = num1 / num2;
            }
            else if (operatorr == "+")
            {
                result = num1 + num2;
            }
            else if (operatorr == "-")
            {
                result = num1 - num2;
            }

            return result;
        }
    }
}