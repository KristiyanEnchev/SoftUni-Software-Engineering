using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            if (num1 < 100)
            {
                Console.WriteLine("Less than 100");
            }
            else if (num1 >= 100 && num1 <= 200)
            {
                Console.WriteLine("Between 100 and 200");
            }
            else if (num1 > 200)
            {
                Console.WriteLine("Greater than 200");
            }
        }
    }
}
