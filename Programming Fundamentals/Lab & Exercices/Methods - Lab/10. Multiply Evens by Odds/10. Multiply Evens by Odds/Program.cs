using System;
using System.Linq;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Math.Abs(int.Parse(Console.ReadLine()));

            int result = Result(num);
            Console.WriteLine(result);
        }

        static int Result(int num)
        {
            int rezult = OddNumbersInNum(num) * EvenNumbersInNum(num);
            return rezult;
        }
        static int EvenNumbersInNum(int num)
        {

            int sumOfEvens = 0;
            while (num != 0)
            {
                int nextNum = num % 10;

                if (nextNum % 2 == 0)
                {
                    sumOfEvens += nextNum;
                }
                num -= nextNum;
                num /= 10;

            }

            return sumOfEvens;
        }
        static int OddNumbersInNum(int num)
        {

            int sumOfOdds = 0;

            while (num != 0)
            {
                int nextNum = num % 10;

                if (nextNum % 2 == 1)
                {
                    sumOfOdds += nextNum;
                }
                num -= nextNum;
                num /= 10;

            }

            return sumOfOdds;
        }
    }
}