using System;

namespace ConsoleApp64
{
    class Program
    {
        static void Main(string[] args)
        {
            int rangeTo = int.Parse(Console.ReadLine());

            AllNumberInRange(rangeTo);
        }

        public static void AllNumberInRange(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                bool isOdd = false;
                string number = i.ToString();
                int sumOfDigits = 0;
                for (int j = 0; j < number.Length; j++)
                {
                    int parsedNumber = (int)number[j];
                    if (parsedNumber % 2 != 0)
                    {
                        isOdd = true;
                    }
                    sumOfDigits += parsedNumber;
                }

                if (isOdd && sumOfDigits % 8 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}