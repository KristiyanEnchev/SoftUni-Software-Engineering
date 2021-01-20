using System;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());

            switch (comand)
            {
                case "add":
                    Adding(numberOne, numberTwo);
                    break;
                case "subtract":
                    Substraction(numberOne, numberTwo);
                    break;
                case "multiply":
                    Multiplication(numberOne, numberTwo);
                    break;
                case "divide":
                    Division(numberOne, numberTwo);
                    break;
            }
        }

        private static void Substraction(int numOne, int numTwo)
        {
            Console.WriteLine(numOne - numTwo);
        }
        private static void Division(int numOne, int numTwo)
        {
            Console.WriteLine(numOne / numTwo);
        }
        private static void Multiplication(int numOne, int numTwo)
        {
            Console.WriteLine(numOne * numTwo);
        }
        private static void Adding(int numOne, int numTwo)
        {
            Console.WriteLine(numOne + numTwo);
        }
    }
}
