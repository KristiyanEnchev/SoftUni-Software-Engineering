using System;

namespace ConsoleApp64
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input == "int")
            {
                int number = int.Parse(Console.ReadLine());
                IntegerMethoot(number);
            }
            else if (input == "real")
            {
                double number = double.Parse(Console.ReadLine());
                RealNumbersMethood(number);
            }
            else if (input == "string")
            {
                string result = Console.ReadLine();
                StringMethoot(result);
            }
        }

        public static void IntegerMethoot(int num)
        {
            int result = num * 2;
            Console.WriteLine(result);
        }

        public static void RealNumbersMethood(double num)
        {
            double result = num * 1.5;
            Console.WriteLine($"{result:f2}");
        }

        public static void StringMethoot(string number)
        {
            string output = $"${number}$";
            Console.WriteLine(output);
        }
    }
}