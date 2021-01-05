using System;

namespace ConsoleApp55
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int digit = 0;
            int count = 0;
            for (int r = num.Length - 1; r >= 0; r--)
            {
                count++;
                if (count == 1)
                {
                    digit = int.Parse(num[r].ToString());
                }
            }
            switch (digit)
            {
                case 1:
                    Console.WriteLine("one");
                    break;
                case 2:
                    Console.WriteLine("two");
                    break;
                case 3:
                    Console.WriteLine("three");
                    break;
                case 4:
                    Console.WriteLine("four");
                    break;
                case 5:
                    Console.WriteLine("five");
                    break;
                case 6:
                    Console.WriteLine("six");
                    break;
                case 7:
                    Console.WriteLine("seven");
                    break;
                case 8:
                    Console.WriteLine("eighт");
                    break;
                case 9:
                    Console.WriteLine("nine");
                    break;
                case 0:
                    Console.WriteLine("zero");
                    break;
            }
        }
    }
}
