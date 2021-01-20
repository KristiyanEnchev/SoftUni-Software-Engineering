using System;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            double result = Calculation(num, power);
            Console.WriteLine(result);
        }

        static double Calculation(double number, int stepen)
        {
            double result = 1;
            for (int i = 0; i < stepen; i++)
            {
                result *= number;
            }

            return result;
        }
    }
}