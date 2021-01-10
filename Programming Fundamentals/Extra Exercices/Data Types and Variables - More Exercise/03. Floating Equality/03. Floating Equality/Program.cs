using System;

class Program
{
    static void Main(string[] args)
    {
        decimal numA = decimal.Parse(Console.ReadLine());
        decimal numB = decimal.Parse(Console.ReadLine());

        decimal eps = 0.000001m;

        if (Math.Abs(numA - numB) < eps)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
    }
}