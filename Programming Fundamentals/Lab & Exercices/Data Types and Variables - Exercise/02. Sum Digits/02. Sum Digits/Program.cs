using System;

namespace ConsoleApp56
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < num.ToString().Length; i++)
            {
                int digit = int.Parse(num.ToString()[i].ToString());
                sum += digit;
            }
            Console.WriteLine(sum);
        }
    }
}
